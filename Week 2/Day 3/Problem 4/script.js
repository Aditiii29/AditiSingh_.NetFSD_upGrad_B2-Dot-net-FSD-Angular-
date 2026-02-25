// ================== STATE ==================
const products = [
    "Laptop",
    "Smartphone",
    "Headphones",
    "Keyboard",
    "Mouse",
    "Monitor",
    "Tablet",
    "Smartwatch"
];

let filteredProducts = [...products]; // app state


// ================== SELECT ELEMENTS ==================
const searchInput = document.getElementById("searchInput");
const productList = document.getElementById("productList");


// ================== RENDER FUNCTION ==================
const renderProducts = (items) => {

    productList.innerHTML = "";

    if (items.length === 0) {
        productList.innerHTML =
            `<li class="no-result">No Results Found</li>`;
        return;
    }

    items.forEach(product => {
        const li = document.createElement("li");
        li.textContent = product;
        productList.appendChild(li);
    });
};


// ================== FILTER FUNCTION ==================
const filterProducts = (searchTerm) => {

    filteredProducts = products.filter(product =>
        product.toLowerCase().includes(searchTerm.toLowerCase())
    );

    renderProducts(filteredProducts);
};


// ================== INPUT EVENT ==================
searchInput.addEventListener("input", (event) => {
    filterProducts(event.target.value);
});


// ================== EVENT DELEGATION ==================
productList.addEventListener("click", (event) => {

    if (event.target.tagName === "LI" &&
        !event.target.classList.contains("no-result")) {

        alert(`You selected: ${event.target.textContent}`);
    }

});


// ================== INITIAL RENDER ==================
renderProducts(products);