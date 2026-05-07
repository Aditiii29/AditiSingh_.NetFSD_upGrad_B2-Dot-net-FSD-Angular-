import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../services/contact';
import { Contact } from '../models/contact';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.html'
})
export class ContactDetailComponent {

  contact?: Contact;

  constructor(private contactService: ContactService) {
    this.contact = this.contactService.getContactById(1);
  }
}