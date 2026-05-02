import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContactService } from '../services/contact';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.html'
})
export class ContactDetailComponent {

  contact: any;

  constructor(private service: ContactService) {
    this.contact = this.service.getContactById(1); // hardcoded for Level-1
  }
}