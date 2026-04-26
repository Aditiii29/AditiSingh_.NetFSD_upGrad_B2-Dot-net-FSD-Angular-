// ─── Models ──────────────────────────────────────────────────────────────────

interface User {
  id: number;
  name: string;
}

interface Product {
  id: number;
  title: string;
}

// ─── Generic Interface ────────────────────────────────────────────────────────

interface Repository<T> {
  add(item: T): void;
  getAll(): T[];
}

// ─── Generic Class ────────────────────────────────────────────────────────────

class DataManager<T> implements Repository<T> {
  private items: T[] = [];

  add(item: T): void {
    this.items.push(item);
  }

  getAll(): T[] {
    return this.items;
  }
}

// ─── Generic Function ─────────────────────────────────────────────────────────

function getFirstElement<T>(items: T[]): T {
  return items[0];
}

// ─── Use Case: User Management ────────────────────────────────────────────────

const userManager = new DataManager<User>();
userManager.add({ id: 1, name: "Alice" });
userManager.add({ id: 2, name: "Bob" });
userManager.add({ id: 3, name: "Charlie" });

console.log("All Users:", userManager.getAll());
console.log("First User:", getFirstElement(userManager.getAll()));

// ─── Use Case: Product Management ─────────────────────────────────────────────

const productManager = new DataManager<Product>();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Phone" });
productManager.add({ id: 103, title: "Tablet" });

console.log("All Products:", productManager.getAll());
console.log("First Product:", getFirstElement(productManager.getAll()));