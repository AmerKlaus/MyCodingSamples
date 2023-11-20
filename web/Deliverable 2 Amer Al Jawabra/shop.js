const products = [
    { id: 1, name: 'ASUS TUF Gaming F15 Gaming Laptop', category: 'laptops', price: 748.00, image: 'products/product1.jpg', brand: 'ASUS COMPUTER INTL', modelName: 'ASUS TUF Gaming F15 Gaming Laptop 15.6”', cpu: 'Intel Core i5-11400H', ram: '8GB DDR4 RAM', hardDisk: '512GB PCIe SSD Gen 3', video: 'https://www.youtube.com/embed/-re5dzBei4k', author: 'UFD Tech'},
    { id: 2, name: 'ROG Strix G10DK Gaming Desktop PC', category: 'desktops', price: 799.99, image: 'products/product2.jpg', brand: 'ASUS COMPUTER INTL', modelName: 'ROG Strix G10DK Gaming Desktop PC', cpu: 'AMD Ryzen 5 3600X', ram: '12GB DDR4 RAM', hardDisk: '512GB PCIe SSD', video: 'https://www.youtube.com/embed/bjw1PAhIfo4', author: 'TechNitWit'},
    { id: 3, name: 'OTVOC VocBook 15', category: 'laptops', price: 449.99, image: 'products/product3.jpg', brand: 'OTVOC', modelName: 'VocBook 15 15.6 inch', cpu: 'Intel Celeron N5100', ram: '16GB RAM', hardDisk: '512GB PCIE NvMe SSD', video: 'https://www.youtube.com/embed/a-aOJLBzrE4', author: 'OSReviews'},
    { id: 4, name: 'Acer Aspire TC-1760-EA92', category: 'desktops', price: 499.99, image: 'products/product4.jpg', brand: 'Acer', modelName: 'TC-1760-EA92', cpu: 'Intel UHD Graphics 730', ram: '8GB RAM', hardDisk: '512GB SSD', video: 'https://www.youtube.com/embed/pHAqjnr6TCs', author: 'Chris G'},
    { id: 5, name: 'Logitech M720 Triathlon Multi-Device Wireless Mouse', category: 'accessories', price: 39.99, image: 'products/product5.jpg', brand: 'Logitech', modelName: 'Logitech M720 Triathlon', connectivity: 'Bluetooth/USB', color: 'Black', video: 'https://www.youtube.com/embed/AJfY1r27M_c', author: 'kendidshoots'},
    { id: 6, name: 'Logitech G305 LIGHTSPEED Wireless Gaming Mouse', category: 'accessories', price: 49.98, image: 'products/product6.jpg', brand: 'Logitech', modelName: 'Logitech G305', connectivity: 'Wireless USB', color: 'Black', video: 'https://www.youtube.com/embed/1X2q9lE8jzY', author: 'Pulse Review'},
    { id: 7, name: 'Logitech MX Keys Advanced Wireless Illuminated Keyboard', category: 'accessories', price: 118.99, image: 'products/product7.jpg', brand: 'Logitech', modelName: 'Logitech MX Keys', connectivity: 'Bluetooth', color: 'Black', video: 'https://www.youtube.com/embed/9Agdcf-oJdw', author: 'Hardware Canucks'},
    { id: 8, name: 'Keychron K4 Hot Swappable Mechanical Gaming Keyboard', category: 'accessories', price: 158.99, image: 'products/product8.jpg', brand: 'Keychron', modelName: 'Keychron K4 V2', connectivity: 'Bluetooth/Wired', color: 'Red Swich', video: 'https://www.youtube.com/embed/DT3bWjoPAos', author: 'TaeKeyboards'}
];

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
            <img src="${product.image}" onclick="handleProductClick(event)" value="${product.id}" alt="${product.name}">
            <h2>${product.name}</h2>
            <p>$${product.price.toFixed(2)}</p>
            <button onclick="handleProductAdd(event)" alt="${product.name}" value="${product.id}">Add to Cart</button>
        `;

        productContainer.appendChild(productDiv);
    });

    handleProductClick = (evt) => {
        const clicked = products.filter(product => product.id == evt.target.getAttribute("value"));
        sessionStorage.setItem("product", JSON.stringify(clicked[0]));
        window.location.href = `detail.html?productId=${clicked[0].id}`;
    }

    handleProductAdd = (evt) => {
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
    }
}

// Function to handle filter changes
function filterProducts() {
    const categoryFilter = document.getElementById('category').value;
    const sortOption = document.getElementById('sort').value;
    renderProducts(categoryFilter, sortOption);
}

// Function to handle sort changes
function sortProducts() {
    const categoryFilter = document.getElementById('category').value;
    const sortOption = document.getElementById('sort').value;
    renderProducts(categoryFilter, sortOption);
}

// Initial rendering of products when the page loads
document.addEventListener('DOMContentLoaded', function () {
    renderProducts('all', 'price-asc');
});