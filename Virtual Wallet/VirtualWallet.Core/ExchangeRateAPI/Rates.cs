using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Wallet.VirtualWallet.Domain.Enums;

namespace VirtualWallet.Application.ExchangeRateAPI
{
    public class Rates
    {
        public static RatesJson GetExchangeRates(string currency)
        {
            try
            {
                String URLString = $"https://v6.exchangerate-api.com/v6/c09e39880dca3479161fcf56/latest/{currency}";
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    return JsonConvert.DeserializeObject<RatesJson>(json);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static PairRatesJson GetExchangeRates(string oldCurrency, string newCurrency)
        {
            try
            {
                String URLString = $"https://v6.exchangerate-api.com/v6/c09e39880dca3479161fcf56/pair/{oldCurrency}/{newCurrency}";
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString(URLString);
                    return JsonConvert.DeserializeObject<PairRatesJson>(json);
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
