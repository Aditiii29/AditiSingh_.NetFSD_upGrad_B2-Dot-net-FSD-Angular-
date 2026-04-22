"use strict";
// ============================================================
//  USER PROFILE DATA HANDLING - TypeScript Basics
// ============================================================
// -------------------------------------------------------
// STEP 1: Variable Declaration with Explicit Types
// -------------------------------------------------------
// 'const' is used for values that NEVER change
const userName = "John Doe";
const email = "john@example.com";
// 'let' is used for values that CAN change later
let age = 25;
let isSubscribed = true;
// -------------------------------------------------------
// STEP 2: Type Inference (No explicit type needed)
// TypeScript automatically figures out the type!
// -------------------------------------------------------
// TypeScript infers this as type: string
let city = "New York";
// TypeScript infers this as type: number
let profileViews = 1500;
// -------------------------------------------------------
// STEP 3: Operators - Increment age by 1
// -------------------------------------------------------
// Before increment
console.log("Age before increment:", age); // 25
age += 1; // Same as: age = age + 1
// After increment
console.log("Age after increment:", age); // 26
// -------------------------------------------------------
// STEP 4: Template Literals - Formatted Profile Message
// -------------------------------------------------------
// Backtick strings allow you to embed variables using ${}
const profileMessage = `Hello ${userName}, you are ${age} years old and your email is ${email}`;
console.log("\n--- Profile Message ---");
console.log(profileMessage);
// -------------------------------------------------------
// STEP 5: Operators - Check Premium Plan Eligibility
// -------------------------------------------------------
// Logical AND (&&): BOTH conditions must be true
const isEligibleForPremium = age > 18 && isSubscribed;
console.log("\n--- Premium Eligibility Check ---");
console.log("Age > 18?              ", age > 18); // true (26 > 18)
console.log("Is Subscribed?         ", isSubscribed); // true
console.log("Eligible for Premium?  ", isEligibleForPremium); // true
// -------------------------------------------------------
// STEP 6: Print All Results
// -------------------------------------------------------
console.log("\n========== USER PROFILE SUMMARY ==========");
console.log(`Name            : ${userName}`);
console.log(`Age             : ${age}`);
console.log(`Email           : ${email}`);
console.log(`Subscribed      : ${isSubscribed}`);
console.log(`City            : ${city}`);
console.log(`Profile Views   : ${profileViews}`);
console.log(`Premium Access  : ${isEligibleForPremium}`);
console.log("==========================================");
