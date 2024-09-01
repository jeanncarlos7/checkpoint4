using System.Threading.Tasks;

namespace checkpoint4.Interfaces
{
    public interface IConversionRate
    {
        Task<decimal> GetUsdToBrlRateAsync();
    }
}
