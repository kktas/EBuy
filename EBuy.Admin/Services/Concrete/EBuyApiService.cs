using System.Configuration;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.WebEncoders.Testing;
using RestSharp;
using Newtonsoft.Json;
using RestSharp.Authenticators;
using Microsoft.AspNetCore.Mvc;

namespace EBuy.Admin;

public class EBuyApiService : IEBuyApiService
{
    private readonly IConfiguration _configuration;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly string _apiJwtToken;
    private readonly string _baseUrl;
    private readonly RestClientOptions _options;
    private readonly RestClient _client;
    private readonly RestRequest _request;
    public EBuyApiService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
    {
        _configuration = configuration;
        _httpContextAccessor = httpContextAccessor;
        _baseUrl = _configuration["Hosts:EBuy.API"]?.ToString() ?? "";
        _apiJwtToken = _httpContextAccessor?.HttpContext?.Request.Headers["apiJwtToken"].ToString() ?? String.Empty;

        _options = new RestClientOptions($"{_baseUrl}");
        _client = new RestClient(_options);
        _request = new RestRequest();
        _request.AddHeader("Authorization", $"Bearer {_apiJwtToken}");
    }

    #region Get Methods
    public async Task<RestResponse> Get(string url)
    {
        _request.Resource = url;
        return await _client.GetAsync(_request);
    }
    public async Task<T?> Get<T>(string url)
    {
        _request.Resource = url;
        return await _client.GetAsync<T>(_request);
    }
    #endregion

    #region Post Methods
    public async Task<RestResponse> Post(string url, object body)
    {
        _request.Resource = url;
        _request.AddBody(body);
        return await _client.PostAsync(_request);
    }
    public async Task<T?> Post<T>(string url, object body)
    {
        _request.Resource = url;
        _request.AddBody(body);
        return await _client.PostAsync<T>(_request);
    }
    #endregion

    #region Put Methods
    public async Task<RestResponse> Put(string url, object body)
    {
        _request.Resource = url;
        _request.AddBody(body);
        return await _client.PutAsync(_request);
    }
    public async Task<T?> Put<T>(string url, object body)
    {
        _request.Resource = url;
        _request.AddBody(body);
        return await _client.PutAsync<T>(_request);
    }
    #endregion

    #region Delete Methods
    public async Task<RestResponse> Delete(string url)
    {
        _request.Resource = url;
        return await _client.DeleteAsync(_request);
    }
    public async Task<T?> Delete<T>(string url)
    {
        _request.Resource = url;
        return await _client.DeleteAsync<T>(_request);
    }
    #endregion
}
