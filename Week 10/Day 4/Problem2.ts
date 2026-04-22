// ============================================================
//  USER NOTIFICATION SYSTEM - TypeScript Functions
// ============================================================


// -------------------------------------------------------
// STEP 1: Function with Required Parameters
// -------------------------------------------------------

function getWelcomeMessage(name: string): string {
  return `Welcome, ${name}! We are glad to have you here.`;
}


// -------------------------------------------------------
// STEP 2: Optional Parameters (age? means age is optional)
// -------------------------------------------------------

function getUserInfo(name: string, age?: number): string {
  if (age !== undefined) {
    return `User: ${name}, Age: ${age}`;
  }
  return `User: ${name} (Age not provided)`;
}


// -------------------------------------------------------
// STEP 3: Default Parameters (isSubscribed defaults to false)
// -------------------------------------------------------

function getSubscriptionStatus(name: string, isSubscribed: boolean = false): string {
  if (isSubscribed) {
    return `${name} has an ACTIVE subscription.`;
  }
  return `${name} does NOT have a subscription.`;
}


// -------------------------------------------------------
// STEP 4: Return Type - boolean
// -------------------------------------------------------

function isEligibleForPremium(age: number): boolean {
  return age >= 18;  // returns true if age is 18 or above
}


// -------------------------------------------------------
// STEP 5: Arrow Functions (same logic, shorter syntax)
// -------------------------------------------------------

// Arrow version of getWelcomeMessage
const getWelcomeMessageArrow = (name: string): string =>
  `Welcome, ${name}! We are glad to have you here.`;

// Arrow version of isEligibleForPremium
const isEligibleForPremiumArrow = (age: number): boolean => age >= 18;


// -------------------------------------------------------
// STEP 6: Lexical 'this' using Arrow Function inside Object
// -------------------------------------------------------

const NotificationService = {
  appName: "MyAngularApp",

  // Arrow function preserves 'this' from the enclosing object
  getAppNotification: function (): void {
    const send = (): void => {
      // 'this' here refers to NotificationService (lexical this)
      console.log(`[${this.appName}] Notification sent successfully!`);
    };
    send();
  },

  // Another arrow function using this.appName directly
  getWelcomeNotification: function (userName: string): void {
    const message = (): string =>
      `[${this.appName}] Hello ${userName}, welcome to the platform!`;
    console.log(message());
  }
};


// -------------------------------------------------------
// STEP 7: Call All Functions and Print Output
// -------------------------------------------------------

console.log("========== USER NOTIFICATION SYSTEM ==========\n");

// Required parameter
console.log("--- Welcome Message ---");
console.log(getWelcomeMessage("John"));
console.log(getWelcomeMessageArrow("Sarah"));

// Optional parameter
console.log("\n--- User Info ---");
console.log(getUserInfo("John", 25));   // age provided
console.log(getUserInfo("Sarah"));      // age NOT provided

// Default parameter
console.log("\n--- Subscription Status ---");
console.log(getSubscriptionStatus("John", true));   // subscribed
console.log(getSubscriptionStatus("Sarah"));         // default = false

// Boolean return type
console.log("\n--- Premium Eligibility ---");
console.log("John (age 25) eligible?  ", isEligibleForPremium(25));   // true
console.log("Sarah (age 16) eligible? ", isEligibleForPremium(16));   // false
console.log("Arrow - John eligible?   ", isEligibleForPremiumArrow(25)); // true

// Lexical this
console.log("\n--- Notification Service (Lexical this) ---");
NotificationService.getAppNotification();
NotificationService.getWelcomeNotification("John");

console.log("\n===============================================");