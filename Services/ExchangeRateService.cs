using checkpoint.HttpObjetcs;
using checkpoint4.Interfaces;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace checkpoint4.Services
{
    public class ExchangeRateService : IConversionRate
    {
        private readonly HttpClient _httpClient;
        private const string ApiUrl = "https://v6.exchangerate-api.com/v6/f6cd802945ebc9fc7c94c160/latest/USD"; // Substitua YOUR_API_KEY pela chave da API.

        public ExchangeRateService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<decimal> GetUsdToBrlRateAsync()
        {
            var response = await _httpClient.GetAsync(ApiUrl);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException("Falha na chamada à API de câmbio.");
            }

            var json = await response.Content.ReadAsStringAsync();
            var exchangeRateData = JsonSerializer.Deserialize<ExchangeRateResponse>(json);

            return exchangeRateData?.ConversionRate ?? 0;
        }
    }
}
