using Microsoft.AspNetCore.Mvc;
using Virtual_Wallet.Models.ViewModels;
using Virtual_Wallet.VirtualWallet.Domain.Enums;
using VirtualWallet.Application.ExchangeRateAPI;
using VirtualWallet.Common.AdditionalHelpers;

namespace Virtual_Wallet.Controllers.MVC
{
    public class ConverterController : Controller
    {
        [HttpPost]
        public IActionResult ConvertCurrency(string primary, string secondary, string amountAsString)
        {
            var primaryCurrency = Enum.Parse(typeof(Currency), primary).ToString();
            var secondaryCurrency = Enum.Parse(typeof(Currency), secondary).ToString();
            decimal amount = 0;
            try
            {
                amount = Convert.ToDecimal(amountAsString);
            }
            catch (System.FormatException)
            {
            }
            double exchangeRate;

            PairRatesJson rateJson = Rates.GetExchangeRates(primaryCurrency, secondaryCurrency);
            if (rateJson == null)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable, Alerts.FailedCurrencyRate);
            }
            else
            {
                exchangeRate = rateJson.conversion_rate;
            }

            decimal calculatedAmount = Math.Round(amount * (decimal)exchangeRate, 2);

            var response = new
            {
                calculatedAmount = calculatedAmount,
                exchangeRate = exchangeRate
            };

            return Json(response);
        }
    }
}
