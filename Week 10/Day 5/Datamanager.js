"use strict";
// ─── Models ──────────────────────────────────────────────────────────────────
// ─── Generic Class ────────────────────────────────────────────────────────────
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// ─── Generic Function ─────────────────────────────────────────────────────────
function getFirstElement(items) {
    return items[0];
}
// ─── Use Case: User Management ────────────────────────────────────────────────
const userManager = new DataManager();
userManager.add({ id: 1, name: "Alice" });
userManager.add({ id: 2, name: "Bob" });
userManager.add({ id: 3, name: "Charlie" });
console.log("All Users:", userManager.getAll());
console.log("First User:", getFirstElement(userManager.getAll()));
// ─── Use Case: Product Management ─────────────────────────────────────────────
const productManager = new DataManager();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Phone" });
productManager.add({ id: 103, title: "Tablet" });
console.log("All Products:", productManager.getAll());
console.log("First Product:", getFirstElement(productManager.getAll()));
