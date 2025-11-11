import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService } from '../../services/api';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-register',
  imports: [FormsModule],
  templateUrl: './register.html',
  styleUrl: './register.css',
})
export class RegisterComponent {
  username = '';
  password = '';


  constructor(private api: ApiService, private router: Router) {}

register() {
    this.api.post('Auth/register', { username: this.username, password: this.password })
      .subscribe({
        next: res => {
          Swal.fire({
            title: 'ثبت‌نام موفق!',
            text: 'کاربر با موفقیت ثبت شد 🎉',
            icon: 'success',
            confirmButtonText: 'باشه'
          });
        },
        error: err => {
          Swal.fire({
            title: 'خطا!',
            text: err.error?.message || 'مشکلی پیش آمده 😢',
            icon: 'error',
            confirmButtonText: 'باشه'
          });
        }
      });
  }

  goToLogin() {
    this.router.navigate(['/login']);
  }



}
