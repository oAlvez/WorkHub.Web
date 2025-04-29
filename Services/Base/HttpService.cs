using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using WorkHub.Web.Models.Configurations;
using WorkHub.Web.Services.Interfaces.Base;

namespace WorkHub.Web.Services.Base;
public class HttpService(HttpClient _httpClient, IOptions<ApiConfiguration> _api ) : IHttpService
{
    private const int TIMEOUT = 10;
    public async Task<string> GetStringAsync(string url, string? bearerToken = null)
    {
        try
        {
            if (bearerToken is not null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var res = await _httpClient.GetAsync(string.Concat(_api.Value.BaseUrl, url));
            
            return await res.Content.ReadAsStringAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Exception] {url} - Ocorreu um erro na requisição para a API | Erro: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
    public async Task<T?> GetAsync<T>(string url, string? bearerToken = null)
    {
        try
        {
            if (bearerToken is not null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var res = await _httpClient.GetAsync(string.Concat(_api.Value.BaseUrl, url));
            var response = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode is false)
            {
                Console.WriteLine($"Ocorreu um erro na requisição. response: {response}");
                throw new Exception(response);
            }

            return JsonConvert.DeserializeObject<T>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Exception] {url} - Ocorreu um erro na requisição para a API | Erro: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
    public async Task<T?> PostAsync<T>(string url, object data, string? bearerToken = null)
    {
        try
        {
            if (bearerToken is not null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            _httpClient.Timeout = TimeSpan.FromMinutes(20);

            var res = await _httpClient.PostAsJsonAsync(string.Concat(_api.Value.BaseUrl, url), data);
            var response = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode is false)
                throw new Exception(response);

            return JsonConvert.DeserializeObject<T>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Exception] {url} - Ocorreu um erro na requisição para a API | Erro: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
    public async Task<T?> PutAsync<T>(string url, object data, string? bearerToken = null)
    {
        try
        {
            if (bearerToken is not null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            _httpClient.Timeout = TimeSpan.FromMinutes(TIMEOUT);

            var res = await _httpClient.PutAsJsonAsync(string.Concat(_api.Value.BaseUrl, url), data);
            var response = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode is false)
                throw new Exception(response);

            return JsonConvert.DeserializeObject<T>(response);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[Exception] {url} - Ocorreu um erro na requisição para a API | Erro: {ex.Message}");
            throw new Exception(ex.Message);
        }
    }
    public async Task<T?> DeleteAsync<T>(string url, string? bearerToken = null)
    {
        try
        {
            if (bearerToken is not null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            _httpClient.Timeout = TimeSpan.FromMinutes(TIMEOUT);

            var res = await _httpClient.DeleteAsync(string.Concat(_api.Value.BaseUrl, url));
            var response = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode is false)
                throw new Exception(response);

            return JsonConvert.DeserializeObject<T>(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro na requisição.\nErro: {ex.Message}");
        }
    }
    public async Task<T?> DeleteAsync<T>(string url, IEnumerable<Guid> ids, string? bearerToken = null)
    {
        try
        {
            if (bearerToken is not null)
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            _httpClient.Timeout = TimeSpan.FromMinutes(TIMEOUT);

            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri(string.Concat(_api.Value.BaseUrl, url)),
                Content = new StringContent(JsonConvert.SerializeObject(ids), Encoding.UTF8, "application/json")
            };

            var res = await _httpClient.SendAsync(request);
            var response = await res.Content.ReadAsStringAsync();

            if (res.IsSuccessStatusCode is false)
                throw new Exception(response);

            return JsonConvert.DeserializeObject<T>(response);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ocorreu um erro na requisição.\nErro: {ex.Message}");
        }
    }
}