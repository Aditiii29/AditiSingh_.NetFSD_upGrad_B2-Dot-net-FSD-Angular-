import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ContactService } from '../services/contact';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-contact.html'
})
export class AddContactComponent {

  contact = { id: 0, name: '', email: '', phone: '' };

  constructor(private service: ContactService, private router: Router) {}

  add() {
    this.service.addContact(this.contact).subscribe({
      next: () => {
        alert('Added successfully');
        this.router.navigate(['/']);
      },
      error: () => alert('Error adding contact')
    });
  }
}