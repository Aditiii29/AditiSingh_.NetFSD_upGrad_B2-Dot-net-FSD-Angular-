// Store a number
let number = 7;   // You can change this value

// Check Positive or Negative using Ternary Operator
let result = (number >= 0) ? "Positive" : "Negative";
console.log("Number is: " + result);

// Check Even or Odd using if–else
if (number % 2 === 0) {
    console.log("Number is Even");
} else {
    console.log("Number is Odd");
}

// Loop to print numbers from 1 to the given number
console.log("Numbers from 1 to " + number + ":");

for (let i = 1; i <= number; i++) {
    console.log(i);
}
