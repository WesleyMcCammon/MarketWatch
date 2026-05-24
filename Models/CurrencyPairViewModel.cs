namespace MarketWatch.Models;

public class CurrencyPairViewModel
{
    public string Symbol { get; set; }

    public string Description { get; set; }

    public decimal Bid { get; set; }

    public decimal Ask { get; set; }

    public decimal PercentChange { get; set; }

    // Pivot Levels
    public decimal R3 { get; set; }
    public decimal R2 { get; set; }
    public decimal R1 { get; set; }
    public decimal Pivot { get; set; }
    public decimal S1 { get; set; }
    public decimal S2 { get; set; }
    public decimal S3 { get; set; }

    // Value Area
    public decimal ValueAreaHigh { get; set; }
    public decimal PointOfControl { get; set; }
    public decimal ValueAreaLow { get; set; }

    // VWAP + Standard Deviations
    public decimal VWAP { get; set; }

    public decimal StdDevPlus1 { get; set; }
    public decimal StdDevPlus2 { get; set; }
    public decimal StdDevPlus3 { get; set; }

    public decimal StdDevMinus1 { get; set; }
    public decimal StdDevMinus2 { get; set; }
    public decimal StdDevMinus3 { get; set; }

    // Previous Day
    public decimal PrevOpen { get; set; }
    public decimal PrevHigh { get; set; }
    public decimal PrevLow { get; set; }
    public decimal PrevClose { get; set; }
}