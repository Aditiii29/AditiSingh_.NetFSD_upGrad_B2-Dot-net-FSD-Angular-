// Store purchase amount
let amount = 4500;   // You can change this value

let discount = 0;
let finalAmount = 0;

// Apply discount rules
if (amount >= 5000) {
    discount = amount * 0.20;   // 20% discount
} 
else if (amount >= 3000) {
    discount = amount * 0.10;   // 10% discount
} 
else {
    discount = 0;               // No discount
}

// Calculate final payable amount
finalAmount = amount - discount;

// Display results
console.log("Purchase Amount: " + amount);
console.log("Discount: " + discount);
console.log("Final Payable Amount: " + finalAmount);
