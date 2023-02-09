using System.Text.Json.Serialization;

namespace FullStackPayPalDemo.Pages;

internal class PayPalOAuthResponse
{
    [JsonPropertyName("access_token")]
    public string AccessToken { get; set; }
}