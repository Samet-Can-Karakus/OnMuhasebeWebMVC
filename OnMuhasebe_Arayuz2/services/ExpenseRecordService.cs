using OnMuhasebe_Arayuz2.Models;

namespace OnMuhasebe_Arayuz2.services
{
    public class ExpenseRecordService
    {
        private readonly HttpClient _httpClient;
        public ExpenseRecordService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<List<ExpenseRecord>> GetExpenseRecordsAsync()
        {
            var response = await _httpClient.GetAsync("http://localhost:5235/api/giderkayit");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<List<ExpenseRecord>>();
        }

        public async Task<ExpenseRecord> GetExpenseRecordByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"http://localhost:5235/api/giderkayit/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<ExpenseRecord>();
        }

        public async Task SaveExpenseRecordAsync(ExpenseRecord record)
        {
            var response = await _httpClient.PostAsJsonAsync("http://localhost:5235/api/giderkayit", record);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateExpenseRecordAsync(ExpenseRecord record)
        {
            var response = await _httpClient.PutAsJsonAsync($"http://localhost:5235/api/giderkayit", record);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteExpenseRecordAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"http://localhost:5235/api/giderkayit/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
