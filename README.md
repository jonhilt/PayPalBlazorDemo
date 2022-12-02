# PayPal Blazor Demo

A quick demo showing one way to integrate PayPal Payments in a Blazor app.

You'll need to log in to the PayPal Developer dashboard here: https://developer.paypal.com/dashboard/

Once there, create a Sandbox account.

You should then be able to log in over at: https://www.sandbox.paypal.com/billing/plans

There you'll want to set up a Subscription product and at least one plan.

Then, to run this demo you'll need to:
- Update the PayPal script reference in wwwroot/index.html (to include your clientId)
- Update the call to PayPalJS in Pages/Index.razor to pass in a valid planId
