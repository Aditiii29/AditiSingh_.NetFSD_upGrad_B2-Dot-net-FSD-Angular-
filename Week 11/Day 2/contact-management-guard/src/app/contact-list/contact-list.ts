import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './contact-list.html'
})
export class ContactListComponent {

  contacts = [
    { id: 1, name: 'Aditi', email: 'aditi@gmail.com', phone: '9876543210' },
    { id: 2, name: 'Ashish', email: 'ashish@gmail.com', phone: '9123456780' }
  ];
}