export {};
// ============================================================
//  EMPLOYEE MANAGEMENT MODULE - TypeScript Classes (OOP)
// ============================================================


// -------------------------------------------------------
// STEP 1: Base Class - Employee
// -------------------------------------------------------

class Employee {

  public id: number;          // accessible everywhere
  protected name: string;     // accessible in this class + subclasses
  private salary: number;     // accessible ONLY in this class

  // Constructor - runs automatically when object is created
  constructor(id: number, name: string, salary: number) {
    this.id = id;
    this.name = name;
    this.salary = salary;
  }

  // -------------------------------------------------------
  // STEP 2: Getter and Setter for salary (private property)
  // -------------------------------------------------------

  // Getter - read the private salary
  getSalary(): number {
    return this.salary;
  }

  // Setter - update salary only if value is valid
  setSalary(value: number): void {
    if (value > 0) {
      this.salary = value;
      console.log(`Salary updated to: ${this.salary}`);
    } else {
      console.log("Invalid salary! Salary must be greater than 0.");
    }
  }

  // -------------------------------------------------------
  // STEP 3: Method to display employee details
  // -------------------------------------------------------

  displayDetails(): void {
    console.log("-----------------------------");
    console.log(`ID     : ${this.id}`);
    console.log(`Name   : ${this.name}`);
    console.log(`Salary : ${this.getSalary()}`);
    console.log("-----------------------------");
  }
}


// -------------------------------------------------------
// STEP 4: Derived Class - Manager (inherits Employee)
// -------------------------------------------------------

class Manager extends Employee {

  public teamSize: number;   // extra property only Manager has

  // Constructor calls base class constructor using super()
  constructor(id: number, name: string, salary: number, teamSize: number) {
    super(id, name, salary);  // calls Employee constructor
    this.teamSize = teamSize;
  }

  // -------------------------------------------------------
  // STEP 5: Method Overriding - override displayDetails()
  // -------------------------------------------------------

  // 'override' keyword makes it clear we're overriding base method
  override displayDetails(): void {
    console.log("-----------------------------");
    console.log(`ID        : ${this.id}`);
    console.log(`Name      : ${this.name}`);       // accessible (protected)
    console.log(`Salary    : ${this.getSalary()}`); // use getter (private)
    console.log(`Team Size : ${this.teamSize}`);
    console.log(`Role      : Manager`);
    console.log("-----------------------------");
  }
}


// -------------------------------------------------------
// STEP 6: Create Objects and Call Methods
// -------------------------------------------------------

console.log("========== EMPLOYEE MANAGEMENT SYSTEM ==========\n");

// --- Employee Object ---
console.log("--- Employee Details ---");
const emp = new Employee(101, "John Doe", 50000);
emp.displayDetails();

// Using getter
console.log(`John's Salary (via getter): ${emp.getSalary()}`);

// Using setter - valid salary
emp.setSalary(55000);

// Using setter - invalid salary
emp.setSalary(-1000);

console.log();

// --- Manager Object ---
console.log("--- Manager Details ---");
const mgr = new Manager(201, "Sarah Smith", 90000, 8);
mgr.displayDetails();

// Using getter on manager
console.log(`Sarah's Salary (via getter): ${mgr.getSalary()}`);

// Using setter on manager
mgr.setSalary(95000);

console.log("\n=================================================");