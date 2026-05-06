import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ContactService } from '../services/contact';  // ← import service

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './contact.html'
})
export class ContactComponent {

  // Use service instead of local array
  constructor(
    private router: Router,
    public contactService: ContactService  // ← inject service
  ) {}

  viewContact(id: number) { this.router.navigate(['/contact', id]); }
}