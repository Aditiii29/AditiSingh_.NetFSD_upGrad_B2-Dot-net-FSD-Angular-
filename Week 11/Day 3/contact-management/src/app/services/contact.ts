import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class ContactService {

  // Shared list — both components read/write here
  contacts = [
    { id: 1, name: 'Alice Johnson', phone: '9876543210', email: 'alice@example.com', city: 'Mumbai' },
    { id: 2, name: 'Bob Smith',     phone: '9123456780', email: 'bob@example.com',   city: 'Delhi' },
    { id: 3, name: 'Carol White',   phone: '9001122334', email: 'carol@example.com', city: 'Pune' }
  ];

  // Add new contact to the shared list
  addContact(name: string, phone: string, email: string): void {
    const newId = this.contacts.length + 1;
    this.contacts.push({ id: newId, name, phone, email, city: 'N/A' });
  }
}