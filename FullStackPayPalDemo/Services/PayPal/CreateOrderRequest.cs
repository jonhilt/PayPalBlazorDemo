using System.Text.Json.Serialization;

namespace FullStackPayPalDemo.Pages.PayPal;

public class CreateOrderRequest
{
    public string Intent { get; set; }
    [JsonPropertyName("purchase_units")]
    public Unit[] PurchaseUnits { get; set; }
}

public class Unit
{
    public Amount Amount { get; set; }
}

public class Amount
{
    [JsonPropertyName("currency_code")]
    public string CurrencyCode { get; set; }
    
    public double Value { get; set; }
}

