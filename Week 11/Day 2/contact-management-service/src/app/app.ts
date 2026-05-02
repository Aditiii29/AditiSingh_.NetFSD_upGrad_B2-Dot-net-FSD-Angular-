import { Component } from '@angular/core';
import { ContactListComponent } from './contact-list/contact-list';
import { AddContactComponent } from './add-contact/add-contact';
import { ContactDetailComponent } from './contact-detail/contact-detail';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ContactListComponent, AddContactComponent, ContactDetailComponent],
  templateUrl: './app.html'
})
export class App {}