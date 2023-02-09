export function renderPaymentUI(container, planId, serverComponent) {

    paypal.Buttons({
        // Order is created on the server and the order id is returned
        createOrder: (data, actions) => {
            return serverComponent.invokeMethodAsync("CreateOrder")
                .then((order) => order.id);
        },
        onApprove: (data, actions) => {
            return serverComponent.invokeMethodAsync("CapturePayment", data.orderID)
                .then((orderData) => {
                    console.log(orderData);
                });
        }
    }).render(container);

}