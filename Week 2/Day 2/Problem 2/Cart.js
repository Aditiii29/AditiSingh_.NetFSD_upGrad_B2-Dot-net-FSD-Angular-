// ================== PRODUCT DATA ==================

export const products = [
    { name: "Laptop", price: 50000, quantity: 1 },
    { name: "Mouse", price: 1000, quantity: 2 },
    { name: "Keyboard", price: 2000, quantity: 1 }
];


// ================== CALCULATE TOTAL ==================

export const calculateCartTotal = (items) =>

    items.reduce((total, product) =>
        total + (product.price * product.quantity),
    0);


// ================== FORMAT INVOICE ==================

export const generateInvoice = (items) => {

    const itemLines = items.map(product =>
        `${product.name} | ₹${product.price} x ${product.quantity} = ₹${product.price * product.quantity}`
    ).join("\n");

    const total = calculateCartTotal(items);

    return `
------------------ INVOICE ------------------

${itemLines}

---------------------------------------------
TOTAL CART VALUE: ₹${total}

---------------------------------------------
`;
};