using Newtonsoft.Json;
using OnMuhasebe_Arayuz2.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
namespace OnMuhasebe_Arayuz2.services;
public class IncomeRecordService
{
    private readonly HttpClient _httpClient;
    public IncomeRecordService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<IncomeRecord>> GetIncomeRecordsAsync()
    {
        var response = await _httpClient.GetAsync("http://localhost:5235/api/gelirkayit");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<List<IncomeRecord>>();
    }

    public async Task<IncomeRecord> GetIncomeRecordByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"http://localhost:5235/api/gelirkayit/{id}");
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadAsAsync<IncomeRecord>();
    }

    public async Task SaveIncomeRecordAsync(IncomeRecord record)
    {
        var response = await _httpClient.PostAsJsonAsync("http://localhost:5235/api/gelirkayit", record);
        response.EnsureSuccessStatusCode();
    }

    public async Task UpdateIncomeRecordAsync(IncomeRecord record)
    {
        var response = await _httpClient.PutAsJsonAsync($"http://localhost:5235/api/gelirkayit", record);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteIncomeRecordAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"http://localhost:5235/api/gelirkayit/{id}");
        response.EnsureSuccessStatusCode();
    }

}

