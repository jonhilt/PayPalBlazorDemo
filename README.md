# PayPal Blazor Demo

A quick demo showing one way to integrate PayPal Payments in a Blazor app.

You'll need to log in to the PayPal Developer dashboard here: https://developer.paypal.com/dashboard/

Once there, create a Sandbox account.

You should then be able to log in over at: https://www.sandbox.paypal.com/billing/plans

There are three strategies demonstrated here:

1. Integration via PayPal checkout which requires an endpoint for subsequent webhook calls
2. A "full stack" version where JS interacts with the Blazor Server component via JS Interop
3. A .NET 8 SSR version (would require an endpoint for webhook calls to fulfil the order) 

## Version 1 (WebHooks approach)

To run this demo you'll need to:
- Update the PayPal script reference in PayPalDemo/wwwroot/index.html (to include your clientId)
- Update the call to PayPalJS in PayPalDemo/Pages/Index.razor to pass in a valid planId

## Version 2 ("Full Stack" approach)

To run this:
- Update the PayPal script reference in FullStackPayPalDemo/Pages/_Host.cshtml (to include your clientId)
- Put your ClientId and AppSecret values in the relevant places in FullStackPayPalDemo/appsettings.json

## Version 3 (".NET 8 SSR" approach)

To run this:
- Put your ClientId and AppSecret values in the relevant places in PayPalSSR/appsettings.Development.json
