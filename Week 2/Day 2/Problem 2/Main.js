import { products, calculateCartTotal, generateInvoice } from "./Cart.js";

// Calculate total
const totalValue = calculateCartTotal(products);

// Generate formatted invoice
const invoice = generateInvoice(products);

// Display in console
console.log(invoice);