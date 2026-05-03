import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ContactService } from '../services/contact';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './contact-detail.html'
})
export class ContactDetailComponent {

  contact: any;

  constructor(private route: ActivatedRoute, private service: ContactService) {}

  ngOnInit() {
    const id = Number(this.route.snapshot.paramMap.get('id'));
    this.service.getContactById(id).subscribe(data => this.contact = data);
  }

  update() {
    this.service.updateContact(this.contact).subscribe(() => {
      alert('Updated successfully');
    });
  }
}