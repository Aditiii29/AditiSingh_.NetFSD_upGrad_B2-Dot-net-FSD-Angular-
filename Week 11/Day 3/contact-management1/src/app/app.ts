import { Component } from '@angular/core';
import { ContactListComponent } from './contact-list/contact-list';
import { ContactDetailComponent } from './contact-detail/contact-detail';
import { AddContactComponent } from './add-contact/add-contact';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    ContactListComponent,
    ContactDetailComponent,
    AddContactComponent
  ],
  templateUrl: './app.html'
})
export class AppComponent {}