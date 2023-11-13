using RestSharp;

namespace EBuy.Admin;

public interface IEBuyApiService
{
    public Task<RestResponse> Get(string url);
    public Task<RestResponse> Post(string url, object body);
    public Task<RestResponse> Put(string url, object body);
    public Task<RestResponse> Delete(string url);
    public Task<T?> Get<T>(string url);
    public Task<T?> Post<T>(string url, object body);
    public Task<T?> Put<T>(string url, object body);
    public Task<T?> Delete<T>(string url);
}
