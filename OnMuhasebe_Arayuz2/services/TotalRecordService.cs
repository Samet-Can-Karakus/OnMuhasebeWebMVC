using OnMuhasebe_Arayuz2.Models;

namespace OnMuhasebe_Arayuz2.services
{
	public class TotalRecordService
	{
		private readonly HttpClient _httpClient;
		public TotalRecordService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<List<TotalRecord>> GetTotalRecordsAsync()
		{
			var response = await _httpClient.GetAsync("http://localhost:5235/api/netkayit");
			response.EnsureSuccessStatusCode();
			return await response.Content.ReadAsAsync<List<TotalRecord>>();
		}
		public async Task<int> SaveTotalRecordAsync(DateTime StartDate, DateTime EndDate)
		{
			var kayit = new { startDate = StartDate, endDate = EndDate };
			var response = await _httpClient.PostAsJsonAsync("http://localhost:5235/api/netkayit", kayit);
			var netKazanc = await response.Content.ReadAsAsync<int>();
			return netKazanc;
			response.EnsureSuccessStatusCode();
		}

	}
}
