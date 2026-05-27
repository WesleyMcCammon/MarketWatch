using Microsoft.AspNetCore.Mvc;
using MarketWatch.Models;

namespace MarketWatch.Controllers
{
    public class DashboardController : Controller
    {
        private CurrencyPairViewModel CreateCurrencyPairViewModel(string symbol, string description)
        {
            var currencyPairViewModel = new CurrencyPairViewModel
            {
                Symbol = symbol,
                Description = description,

                Bid = 1.0845m,
                Ask = 1.0847m,
                PercentChange = 0.42m,
                IndicatorModels = new List<IndicatorModel>
                {
                    new IndicatorModel { Name = "Pivot", Description = "Standard Pivot Points", IndicatorModelValues = new List<IndicatorModelValue>() 
                    {
                        new() { Name = "R3", Value = 1.1100m },
                        new() { Name = "R2", Value = 1.0900m },
                        new() { Name = "R1", Value = 1.0870m },
                        new() { Name = "Pivot", Value = 1.0840m },
                        new() { Name = "S1", Value = 1.0810m },
                        new() { Name = "S2", Value = 1.0780m },
                        new() { Name = "S3", Value = 1.0750m }
                    } },
                    new IndicatorModel { Name = "Volume Profile", Description = "Volume Profile", IndicatorModelValues = new List<IndicatorModelValue>() 
                    {
                        new() { Name = "Value Area High", Value = 1.0860m },
                        new() { Name = "Point of Control", Value = 1.0842m },
                        new() { Name = "Value Area Low", Value = 1.0820m }
                    } },
                    new IndicatorModel { Name = "VWAP", Description = "VWAP", IndicatorModelValues = new List<IndicatorModelValue>() 
                    {
                        new() { Name = "VWAP", Value = 1.0843m }, 
                        new() { Name = "Std Dev +1", Value = 1.0865m },
                        new() { Name = "Std Dev +2", Value = 1.0885m },
                        new() { Name = "Std Dev +3", Value = 1.0905m },
                        new() { Name = "Std Dev -1", Value = 1.0825m },
                        new() { Name = "Std Dev -2", Value = 1.0805m },   
                        new() { Name = "Std Dev -3", Value = 1.0785m }
                    } },
                    new() { Name = "Prev Day OHLC", Description = "Prev Day OHLC", IndicatorModelValues = new List<IndicatorModelValue>() 
                    {
                        new() { Name = "Open", Value = 1.0800m },
                        new() { Name = "High", Value = 1.0880m },
                        new() { Name = "Low", Value = 1.0780m },
                        new() { Name = "Close", Value = 1.0830m }
                    } }
                }
            };

            var pivots = currencyPairViewModel.IndicatorModels.Where(i => i.Name == "Pivot").First();
            return currencyPairViewModel;
        }
        public IActionResult Index()
        {
            IDictionary<string, string> list = new Dictionary<string, string>();

            var model = new List<CurrencyPairViewModel>();
            model.Add(CreateCurrencyPairViewModel("EUR/USD", "Euro/US Dollar"));
            model.Add(CreateCurrencyPairViewModel("USD/JPY", "US Dollar/Japanese Yen"));
            model.Add(CreateCurrencyPairViewModel("GBP/USD", "British Pound/US Dollar"));
            model.Add(CreateCurrencyPairViewModel("AUD/USD", "Australian Dollar/US Dollar"));
            model.Add(CreateCurrencyPairViewModel("USD/CAD", "US Dollar/Canadian Dollar"));
            model.Add(CreateCurrencyPairViewModel("USD/CHF", "US Dollar/Swiss Franc"));
            model.Add(CreateCurrencyPairViewModel("NZD/USD", "New Zealand Dollar/US Dollar"));

            return View(model);
        }
    }
}
