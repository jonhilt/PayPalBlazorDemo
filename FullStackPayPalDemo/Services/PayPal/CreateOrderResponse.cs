using System.Text.Json.Serialization;

namespace FullStackPayPalDemo.Services.PayPal;

public class CreateOrderResponse
{
    public string Id { get; set; }
    public string Status { get; set; }
    [JsonPropertyName("payment_source")]
    public Payment_source PaymentSource { get; set; }
    public Links[] Links { get; set; }
}

public class Payment_source
{
    public Paypal PayPal { get; set; }
}

public class Paypal
{

}