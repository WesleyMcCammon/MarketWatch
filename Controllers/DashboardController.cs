using Microsoft.AspNetCore.Mvc;
using MarketWatch.Models;

namespace MarketWatch.Controllers
{
    public class DashboardController : Controller
    {
        private CurrencyPairViewModel CreateCurrencyPairViewModel(string symbol, string description)
        {
            return new CurrencyPairViewModel
            {
                Symbol = symbol,
                Description = description,

                Bid = 1.0845m,
                Ask = 1.0847m,
                PercentChange = 0.42m,

                R3 = 1.0920m,
                R2 = 1.0900m,
                R1 = 1.0870m,
                Pivot = 1.0840m,
                S1 = 1.0810m,
                S2 = 1.0780m,
                S3 = 1.0750m,

                ValueAreaHigh = 1.0860m,
                PointOfControl = 1.0842m,
                ValueAreaLow = 1.0820m,

                VWAP = 1.0843m,

                StdDevPlus1 = 1.0865m,
                StdDevPlus2 = 1.0885m,
                StdDevPlus3 = 1.0905m,

                StdDevMinus1 = 1.0825m,
                StdDevMinus2 = 1.0805m,
                StdDevMinus3 = 1.0785m,

                PrevOpen = 1.0800m,
                PrevHigh = 1.0880m,
                PrevLow = 1.0780m,
                PrevClose = 1.0830m
            };
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
