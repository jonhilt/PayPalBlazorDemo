using System.Text.Json;
using FullStackPayPalDemo.Pages.PayPal;
using FullStackPayPalDemo.Services.PayPal;
using PayPalDemo.Services;
using RestSharp;

namespace FullStackPayPalDemo.Pages;

public class PayPalService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public PayPalService(HttpClient httpClient, IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = httpClient;
    }
    public async Task<CreateOrderResponse> PlaceOrder(CreateOrderRequest orderRequest)
    {
        var client = new RestClient("https://api-m.sandbox.paypal.com");
        var request = new RestRequest("v2/checkout/orders", Method.Post);
        request.AddHeader("Authorization", $"Bearer {await GetAccessToken()}");
        request.AddHeader("Content-Type", "application/json");
        request.AddJsonBody(orderRequest);

        var response = await client.PostAsync(request);
        if (response.IsSuccessful)
        {
            return JsonSerializer.Deserialize<CreateOrderResponse>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        throw response.ErrorException;
    }

    public async Task<CapturePaymentResponse> CapturePayment(string orderId)
    {
        var client = new RestClient("https://api-m.sandbox.paypal.com");
        var request = new RestRequest($"v2/checkout/orders/{orderId}/capture", Method.Post);
        request.AddHeader("Authorization", $"Bearer {await GetAccessToken()}");
        request.AddHeader("Content-Type", "application/json");
        
        var response = await client.PostAsync(request);
        if (response.IsSuccessful)
        {
            return JsonSerializer.Deserialize<CapturePaymentResponse>(response.Content, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }

        throw response.ErrorException;
    }

    private async Task<string> GetAccessToken()
    {
        var clientId = _configuration.GetValue<string>("PayPal:ClientId");
        var appSecret = _configuration.GetValue<string>("PayPal:AppSecret");
        var auth = (clientId + ":" + appSecret).ToBase64();

        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri("https://api-m.sandbox.paypal.com/v1/oauth2/token"),
            Headers = { {"Authorization", $"Basic {auth}" }  },
            Content = new StringContent("grant_type=client_credentials")
        };
        
        using (var response = await _httpClient.SendAsync(request))
        {
            response.EnsureSuccessStatusCode();
            var body = await response.Content.ReadFromJsonAsync<PayPalOAuthResponse>();
            return body.AccessToken;
        }
    }
}
