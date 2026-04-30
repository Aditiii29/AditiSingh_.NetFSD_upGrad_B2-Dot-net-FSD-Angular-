import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-contact',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './add-contact.html'
})
export class AddContactComponent {

  contact = {
    name: '',
    email: '',
    phone: ''
  };

  constructor(private router: Router) {}

  addContact() {
    console.log(this.contact);
    alert('Contact Added!');

    this.router.navigate(['/contacts']); // ✅ programmatic navigation
  }
}