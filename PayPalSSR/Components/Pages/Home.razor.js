function initialisePayPal() {

    if(paypal.Buttons.instances.length >= 1) return;

    let container = document.getElementById('paypal_container');
    paypal.Buttons({
        style: {
            shape: 'rect',
            color: 'gold',
            layout: 'vertical',
            label: 'subscribe'
        },
        createSubscription: function (data, actions) {
            return actions.subscription.create({
                // replace with your own plan Id
                plan_id: 'P-61S92112RP924735VMOE434Y'
            });
        },
        onApprove: function (data, actions) {
            alert(data.subscriptionID); // You can add optional success message for the subscriber here
        }
    }).render(container); // Renders the PayPal button 

}

export function onUpdate() {
    initialisePayPal();
}