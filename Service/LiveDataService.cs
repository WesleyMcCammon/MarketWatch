using MarketWatch.Hubs;
using MarketWatch.Models;
using Microsoft.AspNetCore.SignalR;

namespace MarketWatch.Service;

public class LiveDataService : BackgroundService
{
    private readonly IHubContext<LiveDataHub> _liveDataHub;

    private readonly Random _random = new();

    public LiveDataService(
        IHubContext<LiveDataHub> liveDataHub)
    {
        _liveDataHub = liveDataHub;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var prices = new List<BidAsk>
            {
                new()
                {
                    Symbol = "EUR/USD",
                    Bid = 1.0845m,
                    Ask = 1.0847m,
                    PercentChange = 0.42m
                },

                new()
                {
                    Symbol = "GBP/USD",
                    Bid = 1.2740m,
                    Ask = 1.2742m,
                    PercentChange = -0.15m
                },

                new()
                {
                    Symbol = "USD/JPY",
                    Bid = 1.2740m,
                    Ask = 1.2742m,
                    PercentChange = -0.15m
                },

                new()
                {
                    Symbol = "AUD/USD",
                    Bid = 1.2740m,
                    Ask = 1.2742m,
                    PercentChange = -0.15m
                },

                new()
                {
                    Symbol = "USD/CAD",
                    Bid = 1.2740m,
                    Ask = 1.2742m,
                    PercentChange = -0.15m
                },

                new()
                {
                    Symbol = "USD/CHF",
                    Bid = 1.2740m,
                    Ask = 1.2742m,
                    PercentChange = -0.15m
                },

                new()
                {
                    Symbol = "NZD/USD",
                    Bid = 1.2740m,
                    Ask = 1.2742m,
                    PercentChange = -0.15m
                }


            //model.Add(CreateCurrencyPairViewModel("EUR/USD", "Euro/US Dollar"));
            //model.Add(CreateCurrencyPairViewModel("USD/JPY", "US Dollar/Japanese Yen"));
            //model.Add(CreateCurrencyPairViewModel("GBP/USD", "British Pound/US Dollar"));
            //model.Add(CreateCurrencyPairViewModel("AUD/USD", "Australian Dollar/US Dollar"));
            //model.Add(CreateCurrencyPairViewModel("USD/CAD", "US Dollar/Canadian Dollar"));
            //model.Add(CreateCurrencyPairViewModel("USD/CHF", "US Dollar/Swiss Franc"));
            //model.Add(CreateCurrencyPairViewModel("NZD/USD", "New Zealand Dollar/US Dollar"));
            };

        while (!stoppingToken.IsCancellationRequested)
        {
            foreach (var price in prices)
            {
                var move =
                    (decimal)(_random.NextDouble() - 0.5)
                    * 0.001m;

                price.Bid += move;
                price.Ask += move;

                price.PercentChange +=
                    move * 10;

                await _liveDataHub.Clients.All.SendAsync(
                    "ReceivePriceUpdate",
                    price,
                    stoppingToken);
            }

            await Task.Delay(
                1000,
                stoppingToken);
        }
    }
}
