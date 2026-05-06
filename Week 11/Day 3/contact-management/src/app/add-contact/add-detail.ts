import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ContactService } from '../services/contact';  // ← import service

@Component({
  selector: 'app-add-detail',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './add-detail.html'
})
export class AddDetailComponent {
  newContact = { name: '', phone: '', email: '' };
  successMessage: string = '';

  constructor(
    private router: Router,
    private contactService: ContactService  // ← inject service
  ) {}

  addContact() {
    if (this.newContact.name && this.newContact.phone && this.newContact.email) {

      // ✅ Adds to the SHARED list in service
      this.contactService.addContact(
        this.newContact.name,
        this.newContact.phone,
        this.newContact.email
      );

      this.successMessage = `✅ Contact "${this.newContact.name}" added!`;
      this.newContact = { name: '', phone: '', email: '' };

    } else {
      alert('Please fill all fields!');
    }
  }

  goBack() { this.router.navigate(['/contacts']); }
}