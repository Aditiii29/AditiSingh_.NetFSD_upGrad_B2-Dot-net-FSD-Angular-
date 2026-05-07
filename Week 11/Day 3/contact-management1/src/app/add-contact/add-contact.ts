import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contact';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-contact.html'
})
export class AddContactComponent {

  contact: Contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

  constructor(private contactService: ContactService) {}

  addContact() {
    this.contactService.addContact(this.contact);

    this.contact = {
      id: 0,
      name: '',
      email: '',
      phone: ''
    };
  }
}