using ContactManagement.Models;
using ContactManagement.Repositories;

// ✅ Top-level statements (C# 9+) — clean and minimal entry point

Console.WriteLine("========================================");
Console.WriteLine("   Contact Management System - Demo     ");
Console.WriteLine("========================================\n");

// ✅ Depend on interface type (SOLID - Dependency Inversion intro)
// Swap ContactRepository for any other implementation without changing this code
ContactManagement.Interfaces.IContactRepository repository = new ContactRepository();

// ── 1. ADD CONTACTS ──────────────────────────────────────────
Console.WriteLine("--- Adding Contacts ---");

repository.AddContact(new Contact
{
    Name = "Alice Johnson",
    Email = "alice@example.com",
    Phone = "9876543210"
});

repository.AddContact(new Contact
{
    Name = "Bob Smith",
    Email = "bob@example.com",
    Phone = "9123456780"
});

repository.AddContact(new Contact
{
    Name = "Charlie Brown",
    Email = "charlie@example.com",
    Phone = "8001234567"
});

// ── 2. GET ALL CONTACTS ───────────────────────────────────────
Console.WriteLine("\n--- All Contacts ---");
foreach (Contact contact in repository.GetAllContacts())
{
    Console.WriteLine(contact);
}

// ── 3. UPDATE A CONTACT ───────────────────────────────────────
Console.WriteLine("\n--- Updating Contact ID 2 ---");
repository.UpdateContact(
    id: 2,
    name: "Bob Updated",
    email: "bob.updated@example.com",
    phone: "9999988888"
);

// ── 4. DELETE A CONTACT ───────────────────────────────────────
Console.WriteLine("\n--- Deleting Contact ID 1 ---");
repository.DeleteContact(1);

// ── 5. FINAL STATE ────────────────────────────────────────────
Console.WriteLine("\n--- Remaining Contacts ---");
foreach (Contact contact in repository.GetAllContacts())
{
    Console.WriteLine(contact);
}

// ── 6. EDGE CASES ─────────────────────────────────────────────
Console.WriteLine("\n--- Edge Case: Delete non-existent ID ---");
repository.DeleteContact(99);

Console.WriteLine("\n--- Edge Case: Update non-existent ID ---");
repository.UpdateContact(99, "Ghost", "ghost@x.com", "1234567890");

Console.WriteLine("\n========================================");
Console.WriteLine("            Demo Complete               ");
Console.WriteLine("========================================");
