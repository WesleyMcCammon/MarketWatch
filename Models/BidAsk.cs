namespace MarketWatch.Models;

public class BidAsk
{
    public string Symbol { get; set; } = string.Empty;

    public decimal Bid { get; set; }

    public decimal Ask { get; set; }

    public decimal PercentChange { get; set; }
}
