// app.ts
import { Component }    from '@angular/core';
import { CommonModule } from '@angular/common';
import { Contact }      from './contact.model';

@Component({
  selector:    'app-root',
  templateUrl: './app.html',
  styleUrl:    './app.css',
  imports:     [CommonModule]   //  Required for ngIf, ngFor, ngClass, ngStyle
})
export class App {

  //  Page title
  title = 'Contact Management';

  // Sample contact list with mix of active and inactive contacts
  contacts: Contact[] = [
    {
      contactId: 1,
      name:      'Alice Johnson',
      email:     'alice@example.com',
      phone:     '9876543210',
      isActive:  true
    },
    {
      contactId: 2,
      name:      'Bob Smith',
      email:     'bob@example.com',
      phone:     '9123456780',
      isActive:  false
    },
    {
      contactId: 3,
      name:      'Charlie Brown',
      email:     'charlie@example.com',
      phone:     '8001234567',
      isActive:  true
    },
    {
      contactId: 4,
      name:      'Diana Prince',
      email:     'diana@example.com',
      phone:     '7009876543',
      isActive:  false
    },
    {
      contactId: 5,
      name:      'Eve Wilson',
      email:     'eve@example.com',
      phone:     '6543210987',
      isActive:  true
    }
  ];
}