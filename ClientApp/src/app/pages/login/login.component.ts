import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { ApiService } from '../../services/api';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AuthService } from '../../services/auth.service';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule, HttpClientModule, CommonModule],
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = '';
  password = '';
  apiMessage = '';

  constructor(private api: ApiService,private router: Router,private authService: AuthService) {}

  login() {
    const payload = { username: this.username, password: this.password };
    this.api.post<{ token: string }>('Auth/login', payload)
      .subscribe({
        next: res => {
          localStorage.setItem('jwt', res.token);

              this.authService.setUserInfo(res);
              this.router.navigate(['/dashboard']);
    
        },
        error: err =>{
         Swal.fire({
            title: 'خطا!',
            text: err.error?.message || 'مشکلی پیش آمده 😢',
            icon: 'error',
            confirmButtonText: 'باشه'
          });

        } 
      });
  }

  testApi() {
    this.api.get<{ message: string }>('Auth/ping')
      .subscribe({
        next: res => this.apiMessage = res.message,
        error: err => this.apiMessage = 'Error: ' + err.message
      });
  }

  register(){
    this.router.navigate(['/register']);
  }
}
