export function renderPaymentUI(container, planId) {
    
    paypal.Buttons({
        style: {
            shape: 'rect',
            color: 'gold',
            layout: 'vertical',
            label: 'subscribe'
        },
        createSubscription: function (data, actions) {
            return actions.subscription.create({
                /* Creates the subscription */
                plan_id: planId
            });
        },
        onApprove: function (data, actions) {
            alert(data.subscriptionID); // You can add optional success message for the subscriber here
        }
    }).render(container); // Renders the PayPal button

}

