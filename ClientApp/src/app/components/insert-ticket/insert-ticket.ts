import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';  // 👈 حتما اضافه کن
import { CommonModule } from '@angular/common'; // 👈 اضافه شد

declare var bootstrap: any;

@Component({
 standalone: true,      
  selector: 'app-insert-ticket',
  imports: [FormsModule,CommonModule  ],    // 👈 اضافه کن
  templateUrl: './insert-ticket.html',
  styleUrls: ['./insert-ticket.css']
})
export class InsertTicketComponent {
ticket = {
  title: '',
  description: '',
  fromDepartmentId: null,
  toDepartmentId: null,
  priority: 'Normal',
  status: 'Open'
};
  departments = [
    { id: 1, name: 'پشتیبانی' },
    { id: 2, name: 'فروش' },
    { id: 3, name: 'مالی' },
  ];

  onSubmit() {
    console.log('تیکت ثبت شد ✅', this.ticket);
    alert('تیکت با موفقیت ثبت شد!');
    const modalEl = document.getElementById('insertTicketModal');
    const modal = bootstrap.Modal.getInstance(modalEl);
    modal?.hide();
  }

  show() {
    const modal = new bootstrap.Modal(document.getElementById('insertTicketModal'));
    modal.show();
  }
}