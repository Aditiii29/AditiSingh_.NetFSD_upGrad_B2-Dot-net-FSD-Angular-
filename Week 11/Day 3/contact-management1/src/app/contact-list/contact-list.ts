import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contact';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-list.html'
})
export class ContactListComponent {

  contacts: Contact[] = [];

  constructor(private contactService: ContactService) {
    this.contacts = this.contactService.getContacts();
  }
}