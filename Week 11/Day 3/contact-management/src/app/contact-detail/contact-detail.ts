import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, RouterLink } from '@angular/router';
import { ContactService } from '../services/contact';  // ← import service

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './contact-detail.html'
})
export class ContactDetailComponent implements OnInit {
  contact: any = null;

  constructor(
    private route: ActivatedRoute,
    private contactService: ContactService  // ← inject service
  ) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    // ✅ Reads from shared service — newly added contacts show here too
    this.contact = this.contactService.contacts.find(c => c.id === id);
  }
}