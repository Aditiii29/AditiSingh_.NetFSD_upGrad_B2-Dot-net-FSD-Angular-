import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contact';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './contact-list.html'
})
export class ContactListComponent {

  contacts: Contact[] = [];

  constructor(private service: ContactService) {}

  ngOnInit() {
    this.loadContacts();
  }

  loadContacts() {
    this.service.getContacts().subscribe({
      next: (data) => this.contacts = data,
      error: () => alert('Error loading contacts')
    });
  }

  delete(id: number) {
    this.service.deleteContact(id).subscribe(() => {
      this.loadContacts();
    });
  }
}