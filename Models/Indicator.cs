namespace MarketWatch.Models;

public class IndicatorModel
{
    public string Name { get; set; } = string.Empty;
    public string Description {  get; set; } = string.Empty;
    public IList<IndicatorModelValue> IndicatorModelValues { get; set; } = default!;

    public IndicatorModel()
    {
        IndicatorModelValues = new List<IndicatorModelValue>();
    }

    public void AddIndicatorValue(string name, decimal value)
    {
        IndicatorModelValues.Add(new IndicatorModelValue { Name = name, Value = value });
    }

    public decimal GetValue(string name)
    {
        var indicatorModelValue = IndicatorModelValues.Where(pair => pair.Name == name).FirstOrDefault();
        return indicatorModelValue != null ? indicatorModelValue.Value : 0m;
    }
}

public class IndicatorModelValue
{
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
}