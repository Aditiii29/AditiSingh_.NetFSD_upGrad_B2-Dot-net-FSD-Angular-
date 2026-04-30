import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact-detail.html'
})
export class ContactDetailComponent {

  contact: any;

  contacts = [
    { id: 1, name: 'Aditi', email: 'aditi@gmail.com', phone: '9876543210' },
    { id: 2, name: 'Ashish', email: 'ashish@gmail.com', phone: '9123456780' }
  ];

  constructor(private route: ActivatedRoute) {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.contact = this.contacts.find(c => c.id === id);
  }
}