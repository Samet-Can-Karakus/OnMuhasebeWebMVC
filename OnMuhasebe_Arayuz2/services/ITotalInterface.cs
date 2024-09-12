using OnMuhasebe_Arayuz2.Models;

namespace OnMuhasebe_Arayuz2.services
{
    public interface ITotalInterface
    {
        Task<IEnumerable<TotalRecord>> GetTotalRecordsAsync();
        Task<int> SaveTotalRecordAsync(DateTime StartDate, DateTime EndDate);
    }
}
