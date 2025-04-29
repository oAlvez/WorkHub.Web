namespace WorkHub.Web.Services.Interfaces.Base;
public interface IHttpService
{
    Task<string> GetStringAsync(string url, string? bearerToken = null);
    Task<T?> GetAsync<T>(string url, string? bearerToken = null);
    Task<T?> PostAsync<T>(string url, object data, string? bearerToken = null);
    Task<T?> PutAsync<T>(string url, object data, string? bearerToken = null);
    Task<T?> DeleteAsync<T>(string url, string? bearerToken = null);
    Task<T?> DeleteAsync<T>(string url, IEnumerable<Guid> ids, string? bearerToken = null);
}