namespace PayPalDemo.Services;

public static class StringHelpers
{
    public static string ToBase64(this string plainText) {
        var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
        return System.Convert.ToBase64String(plainTextBytes);
    }
}