import { Routes } from '@angular/router';
import { AuthGuard } from './guards/auth-guard';
import { ContactDetailComponent } from './contact-detail/contact-detail';
import { ContactComponent } from './contact-list/contact';
import { AddDetailComponent } from './add-contact/add-detail';

export const routes: Routes = [
  { path: '', redirectTo: '/contacts', pathMatch: 'full' },
  { path: 'contacts', component: ContactComponent },
  { path: 'add-contact', component: AddDetailComponent, canActivate: [AuthGuard] },
  { path: 'contact/:id', component: ContactDetailComponent, canActivate: [AuthGuard] },
  { path: '**', redirectTo: '/contacts' }
];