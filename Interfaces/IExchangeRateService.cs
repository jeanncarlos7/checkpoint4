namespace checkpoint.Interfaces
{
    public interface IExchangeRateService
    {
        Task<decimal> GetUsdToBrlRateAsync();
    }
}
