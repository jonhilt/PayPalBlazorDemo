﻿using FullStackPayPalDemo.Pages;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using Index = FullStackPayPalDemo.Pages.Index;

namespace PayPalDemo;

public interface IPayPalJS : IAsyncDisposable
{
    ValueTask<string> SetUpPaymentButton<T>(ElementReference element, string planId,
        DotNetObjectReference<T> dotNetObjectReference) where T : class;
}

public class PayPalJs : IPayPalJS
{
    private readonly Lazy<Task<IJSObjectReference>> moduleTask;

    public PayPalJs(IJSRuntime jsRuntime)
    {
        moduleTask = new(() => jsRuntime.InvokeAsync<IJSObjectReference>(
            "import", "./paypal.js").AsTask());
    }

    public async ValueTask<string> SetUpPaymentButton<T>(ElementReference element, string planId,
        DotNetObjectReference<T> dotNetObjectReference) where T : class
    {
        var module = await moduleTask.Value;
        return await module.InvokeAsync<string>("renderPaymentUI", element, planId, dotNetObjectReference);
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