document.addEventListener('DOMContentLoaded', function () {
    const totalCostContainer = document.getElementById('totalCostContainer');

    // Function to update the total cost UI
    function updateTotalCostUI() {
        // Calculate the total cost based on the products and their quantities in the cart
        const totalCost = cart.reduce((total, product) => total + product.price * product.quantity, 0);

        // Update the content of the total cost container
        totalCostContainer.textContent = `Total Cost: $${totalCost.toFixed(2)}`;

        var order = document.createElement("button");
        order.textContent = "Place Order";
        order.id = "orderButton";

        order.addEventListener('click', function () {
            alert("Your order of " + totalCost + " dollars has been placed. Thank you for shopping at Amer's Shop :)");
        });

        totalCostContainer.appendChild(order);
    }

    // Retrieve the cart from Session Storage
    const cart = JSON.parse(sessionStorage.getItem('cart')) || [];

    // Reference to the cart container in the HTML
    const cartContainer = document.getElementById('cartContainer');

    // Function to update the cart UI
    function updateCartUI() {
        // Clear the existing content in the cart container
        cartContainer.innerHTML = '';

        // Loop through each product in the cart and append it to the cart container
        cart.forEach(product => {
            const cartProductDiv = document.createElement('div');
            cartProductDiv.classList.add('cart-product');

            cartProductDiv.innerHTML = `
                <img src="${product.image}" alt="${product.name}">
                <h2>${product.name}</h2>
                <p>$${product.price.toFixed(2)}</p>
                <p>Quantity: ${product.quantity}</p>
                <button id="removeCartButton" onclick="removeProductFromCart(${product.id})">Remove</button>
            `;

            cartContainer.appendChild(cartProductDiv);
        });
    }

    // Function to remove a product from the cart
    window.removeProductFromCart = function (productId) {
        // Find the index of the product in the cart
        const productIndex = cart.findIndex(product => product.id == productId);

        if (productIndex !== -1) {
            // If the product has more than one quantity, decrease the quantity by one
            if (cart[productIndex].quantity > 1) {
                cart[productIndex].quantity -= 1;
            } else {
                // If the product has only one quantity, remove the entire product from the cart
                cart.splice(productIndex, 1);
            }

            // Save the updated cart back to Session Storage
            sessionStorage.setItem('cart', JSON.stringify(cart));

            // Update the UI to reflect the changes
            updateCartUI();
            updateTotalCostUI();
        }
    };

    updateCartUI();
    updateTotalCostUI();
});