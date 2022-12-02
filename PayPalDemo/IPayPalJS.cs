using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace PayPalDemo;

public interface IPayPalJS : IAsyncDisposable
{
    ValueTask<string> SetUpPaymentButton(ElementReference element, string planId);
}

public class PayPalJs : IPayPalJS
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public PayPalJs(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./paypal.js").AsTask());
    }

    public async ValueTask<string> SetUpPaymentButton(ElementReference element, string planId)
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("renderPaymentUI", element, planId);
    }

    public async ValueTask DisposeAsync()
    {
        if (moduleTask.IsValueCreated)
        {
            var module = await moduleTask.Value;
            await module.DisposeAsync();
        }
    }
}