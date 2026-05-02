import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../services/contact';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-contact.html'
})
export class AddContactComponent {

  contact = {
    id: 0,
    name: '',
    email: '',
    phone: ''
  };

  constructor(private service: ContactService) {}

  add() {
    this.service.addContact(this.contact);
    alert('Contact Added');
  }
}