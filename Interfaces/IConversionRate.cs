using checkpoint.HttpObjetcs;

namespace checkpoint4.Interfaces
{
    public interface IConversionRate
    {
        Task<ExchangeRateResponse> GetUsdRateAsync();
    }
}
