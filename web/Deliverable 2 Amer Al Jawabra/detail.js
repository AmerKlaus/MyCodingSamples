import { getOneProduct } from "./productsManager.js";

let params = new URLSearchParams(location.search);
let id = params.get('productId');

// Calling products from the JSON file
var product = getOneProduct(id).then((data) => {
    product = data;
    renderProducts(product);
});
function renderProducts() {
    const table = document.createElement('table');

    table.classList.add('product-table');

    // Create the <thead> element and its row (<tr>)
    const thead = document.createElement('thead');
    const headerRow = document.createElement('tr');

    // Add header cells (<th>) to the header row
    const headers = ['Brand', 'Model Name', 'CPU', 'RAM', 'Hard Disk'];

    headers.forEach(headerText => {
        const th = document.createElement('th');
        th.textContent = headerText;
        headerRow.appendChild(th);
    });

    // Append the header row to the <thead>
    thead.appendChild(headerRow);

    // Append the <thead> to the <table>
    table.appendChild(thead);

    // Seperating accessories category table

    const table2 = document.createElement('table');

    table2.classList.add('product-table');

    const thead2 = document.createElement('thead');
    const headerRow2 = document.createElement('tr');

    const headers2 = ['Brand', 'Model Name', 'Connectivity', 'Color'];

    headers2.forEach(headerText => {
        const th = document.createElement('th');
        th.textContent = headerText;
        headerRow2.appendChild(th);
    });

    thead2.appendChild(headerRow2);

    table2.appendChild(thead2);
    //

    // Create the <tbody> element
    const tbody = document.createElement('tbody');

    // Create a single data row (<tr>) for the product
    const row = document.createElement('tr');

    // Add cells (<td>) to the row
    const td1 = document.createElement('td');
    td1.textContent = product.brand;

    const td2 = document.createElement('td');
    td2.textContent = product.modelName;

    const td3 = document.createElement('td');
    td3.textContent = product.cpu;

    const td4 = document.createElement('td');
    td4.textContent = product.ram;

    const td5 = document.createElement('td');
    td5.textContent = product.hardDisk;

    const td6 = document.createElement('td');
    td6.textContent = product.connectivity;

    const td7 = document.createElement('td');
    td7.textContent = product.color;

    row.appendChild(td1);
    row.appendChild(td2);
    row.appendChild(td3);
    row.appendChild(td4);
    row.appendChild(td5);

    tbody.appendChild(row);

    // Append the <tbody> to the <table>
    table.appendChild(tbody);

    // Appending for accessories category table
    const tbody2 = document.createElement('tbody');

    const row2 = document.createElement('tr');
    if (product.category == "accessories") {
        row2.appendChild(td1);
        row2.appendChild(td2);
        row2.appendChild(td6);
        row2.appendChild(td7);
    }

    tbody2.appendChild(row2);

    table2.appendChild(tbody2);
    //
    let author = "Video made by : " + product.author;

    const productDetailsContainer = document.getElementById('productDetailsContainer');

    const detailsContainer = document.createElement('div');
    detailsContainer.classList.add('product-details-container');

    const mediaContainer = document.createElement('div');
    mediaContainer.classList.add('product-media-container');

    const imgElement = document.createElement('img');
    imgElement.src = product.image;
    imgElement.alt = product.name;

    const videoContainer = document.createElement('div');
    videoContainer.classList.add('video-container');

    if (product.video) {
        const videoElement = document.createElement('iframe');
        videoElement.src = product.video;
        videoElement.width = '100%';
        videoElement.height = '300';
        videoElement.allowFullscreen = true;

        videoContainer.appendChild(videoElement);
    } else {
        videoContainer.textContent = 'No video available for this product.';
    }

    mediaContainer.appendChild(imgElement);
    mediaContainer.appendChild(videoContainer);

    const detailsDiv = document.createElement('div');
    detailsDiv.classList.add('product-details');
    detailsDiv.innerHTML = `
        <h1>${product.name}</h1>
        <p>$${product.price.toFixed(2)}</p>
        <p>Description:</p>
        ${product.category === 'accessories' ? table2.outerHTML : table.outerHTML}
        <p>${author}</p>
        <button id="buttonImage" class="addToCartBtn">Add to Cart</button>
    `;

    detailsContainer.appendChild(mediaContainer);
    detailsContainer.appendChild(detailsDiv);

    productDetailsContainer.appendChild(detailsContainer);
    handleProductAdd();
}

function handleProductAdd() {
    document.querySelectorAll("#buttonImage").forEach(function (item) {
        item.addEventListener("click", function () {
            // Retrieve existing cart from Session Storage
            let cart = JSON.parse(sessionStorage.getItem('cart')) || [];

            // Check if the product is already in the cart
            const existingProductIndex = cart.findIndex(item => item.id == product.id);

            if (existingProductIndex !== -1) {
                // Increase the quantity by 1
                cart[existingProductIndex].quantity += 1;
            } else {
                // If the product is not in the cart, add it with a quantity of 1
                cart.push({ ...product, quantity: 1 });
            }

            // Save the updated cart back to Session Storage
            sessionStorage.setItem('cart', JSON.stringify(cart));

            alert("You have added " + product.name + " to your shopping cart!");
        })
    })
}