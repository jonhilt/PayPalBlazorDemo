namespace FullStackPayPalDemo.Services.PayPal;

public class CapturePaymentResponse
{
    public string Id { get; set; }
    public string Status { get; set; }
    public Links[] Links { get; set; }
}