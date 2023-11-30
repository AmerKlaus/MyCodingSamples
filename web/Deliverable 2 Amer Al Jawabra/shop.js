import { getAllProducts } from "./productsManager.js";

// Calling products from JSON file

var products = getAllProducts().then((data) => {
    products = data;
    renderProducts('all', 'price-asc');
});

// Function to render products based on current filter and sort options
function renderProducts(categoryFilter, sortOption) {
    // Create productContainer if it doesn't exist
    let productContainer = document.getElementById('productContainer');

    if (!productContainer) {
        productContainer = document.createElement('div');
        productContainer.id = 'productContainer';
        // Append the container to the body or another appropriate element
        document.body.appendChild(productContainer);
    }

    productContainer.innerHTML = ''; // Clear existing products

    // Filter products based on category
    const filteredProducts = categoryFilter === 'all'
        ? products
        : products.filter(product => product.category === categoryFilter);

    // Sort products based on the selected option
    const sortedProducts = sortOption === 'price-asc'
        ? filteredProducts.sort((a, b) => a.price - b.price)
        : sortOption === 'price-desc'
            ? filteredProducts.sort((a, b) => b.price - a.price)
            : filteredProducts;

    // Render products in the product container
    sortedProducts.forEach(product => {
        const productDiv = document.createElement(`div-${product.id}`);
        productDiv.setAttribute("id", product.id);
        productDiv.classList.add('product');
        productDiv.innerHTML = `
            <img src="${product.image}" id="productImage" value="${product.id}" alt="${product.name}">
            <h2>${product.name}</h2>
            <p>$${product.price.toFixed(2)}</p>
            <button id="buttonImage" alt="${product.name}" value="${product.id}">Add to Cart</button>
        `;
        productContainer.appendChild(productDiv);
    });
    handleProductClick();
    handleProductAdd();
    sortProducts();
    filterProducts();
}

function handleProductClick() {
    document.querySelectorAll("#productImage").forEach(function (item) {
        item.addEventListener("click", function (evt) {
            const clicked = products.filter(product => product.id == evt.target.getAttribute("value"));
            window.location.href = `detail.html?productId=${clicked[0].id}`;
        })
    })
}

function handleProductAdd() {
    document.querySelectorAll("#buttonImage").forEach(function (item) {
        item.addEventListener("click", function (evt) {
            const productName = evt.target.getAttribute('alt');
            const productId = evt.target.getAttribute('value');
            const productToAdd = products.find(product => product.id == productId);

            // Retrieve existing cart from Session Storage
            let cart = JSON.parse(sessionStorage.getItem('cart')) || [];

            // Check if the product is already in the cart
            const existingProductIndex = cart.findIndex(item => item.id == productId);

            if (existingProductIndex !== -1) {
                // If the product is already in the cart, you might want to update quantity or handle it differently
                // For simplicity, let's just increase the quantity by 1
                cart[existingProductIndex].quantity += 1;
            } else {
                // If the product is not in the cart, add it with a quantity of 1
                cart.push({ ...productToAdd, quantity: 1 });
            }

            // Save the updated cart back to Session Storage
            sessionStorage.setItem('cart', JSON.stringify(cart));

            alert("You have added " + productName + " to your shopping cart!");
        })
    })
}

// Function to handle filter changes
function filterProducts() {
    document.getElementById('category').addEventListener("change", function (evt) {
        const categoryFilter = document.getElementById('category').value;
        const sortOption = document.getElementById('sort').value;
        renderProducts(categoryFilter, sortOption);
    })
}

// Function to handle sort changes
function sortProducts() {
    document.getElementById('sort').addEventListener("change", function (evt) {
        const categoryFilter = document.getElementById('category').value;
        const sortOption = document.getElementById('sort').value;
        renderProducts(categoryFilter, sortOption);
    })
}