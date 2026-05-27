using MarketWatch.Hubs;
using MarketWatch.Models;
using Microsoft.AspNetCore.SignalR;
using ThinkOrSwimClient;

namespace MarketWatch.Service;

public class LiveDataService : BackgroundService
{
    private readonly IHubContext<LiveDataHub> _liveDataHub;
    private readonly ThinkOrSwimService _thinkOrSwimService = default!;

    private readonly Random _random = new();

    public LiveDataService(
        IHubContext<LiveDataHub> liveDataHub)
    {
        _liveDataHub = liveDataHub;
        _thinkOrSwimService = new ThinkOrSwimService();
        _thinkOrSwimService.ThinkOrSwimEventHandler += this._thinkOrSwimService_ThinkOrSwimEventHandler;
    }

    private void _thinkOrSwimService_ThinkOrSwimEventHandler(ThinkOrSwimClient.Model.ThinkOrSwimQuoteMessage message)
    {    
        var price = new BidAsk
        {
            Symbol = message.Symbol,
            Bid = message.QuoteType == "Bid" ? message.Value : 0,
            Ask = message.QuoteType == "Ask" ? message.Value : 0,
            PercentChange = 0
        };

        _liveDataHub.Clients.All.SendAsync(
            "ReceivePriceUpdate",
            price);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _thinkOrSwimService.Start();
    }
}
