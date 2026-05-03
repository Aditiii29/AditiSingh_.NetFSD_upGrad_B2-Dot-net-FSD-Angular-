import { Routes } from '@angular/router';
import { ContactListComponent } from './contact-list/contact-list';
import { AddContactComponent } from './add-contact/add-contact';
import { ContactDetailComponent } from './contact-detail/contact-detail';

export const routes: Routes = [
  { path: '', component: ContactListComponent },
  { path: 'add', component: AddContactComponent },
  { path: 'detail/:id', component: ContactDetailComponent }
];