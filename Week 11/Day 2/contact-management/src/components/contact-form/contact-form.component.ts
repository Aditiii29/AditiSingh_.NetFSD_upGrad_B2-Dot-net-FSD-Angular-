import { Component } from '@angular/core';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-contact-form',
  templateUrl: './contact-form.component.html'
})
export class ContactFormComponent {

  contact: Contact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    isActive: true
  };

  contacts: Contact[] = [];

  onSubmit(form: any) {
    if (form.valid) {
      this.contact.contactId = this.contacts.length + 1;

      this.contacts.push({ ...this.contact });

      form.reset();
    }
  }
}