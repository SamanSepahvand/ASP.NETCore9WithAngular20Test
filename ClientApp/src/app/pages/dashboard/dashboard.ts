import { Component,OnInit, OnDestroy  } from '@angular/core';
import { ApiService } from '../../services/api';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';
import { AuthService } from '../../services/auth.service';
import { CommonModule, DatePipe } from '@angular/common'; // اضافه کردن DatePipe
import { Chart, registerables } from 'chart.js';

@Component({
  selector: 'app-dashboard',
  imports: [CommonModule, DatePipe],
  templateUrl: './dashboard.html',
  styleUrl: './dashboard.css',
})
export class DashboardComponent implements OnDestroy   {
private intervalId: any;
user: any;


  tickets = [
    { id: 101, user: 'Saman Sepahvand', center: 'مرکز اصلی', status: 'باز' },
    { id: 102, user: 'Ali Rezaei', center: 'مرکز فرعی', status: 'بسته' },
    { id: 103, user: 'Sara Ahmadi', center: 'مرکز اصلی', status: 'در حال پیگیری' }
  ];

  constructor(private api: ApiService,private router: Router,public auth: AuthService) { }

  ngOnInit() {
    this.intervalId = setInterval(() => {
    }, 1000);
  this.user = this.auth.getUserInfo();
     Chart.register(...registerables); // رجیستر کنترلرها و پلاگین‌ها
     this.renderChart();
  }

renderChart() {
    const ctx = document.getElementById('ticketsChart') as HTMLCanvasElement;

    new Chart(ctx, {
      type: 'line', // نوع نمودار
      data: {
        labels: ['دیروز', 'امروز', 'فردا'],
        datasets: [{
          label: 'تعداد تیکت‌ها',
          data: [5, 12, 7],
          borderColor: '#007bff',
          backgroundColor: 'rgba(0, 123, 255, 0.2)',
          fill: true,
          tension: 0.4, // انحنای خط
          pointRadius: 5,
          pointBackgroundColor: '#007bff'
        }]
      },
      options: {
        responsive: true,
        maintainAspectRatio: false, // ⚡ مهم: اندازه canvas با container هماهنگ می‌شود
        plugins: {
          legend: { display: true, position: 'top' }
        },
        scales: {
          x: {
            grid: { display: false },
            title: { display: true, text: 'روز' }
          },
          y: {
            beginAtZero: true,
            title: { display: true, text: 'تعداد تیکت‌ها' }
          }
        }
      }
    });
  }

  ngOnDestroy() {
    clearInterval(this.intervalId);
  }




  /*یه تایم لاینه برای نشون دادن توکن چقدر اعتبار داره*/


  //   currentTime = new Date();
  // countdownSeconds: number | null = null;

  // 


  // ngOnInit() {
//     // آپدیت زمان جاری هر 1 ثانیه
//     this.intervalId = setInterval(() => {
//       this.currentTime = new Date();
//       //this.updateCountdown();
//     }, 1000);
//   }


  // updateCountdown() {
  //   const token = this.auth.getToken();
  //   if (!token) {
  //     this.countdownSeconds = null;
  //     return;
  //   }

  //   try {
  //     const decoded: any = this.auth.decodeToken(token); // متدی که زمان exp رو برگردونه
  //     const now = Math.floor(Date.now() / 1000);
  //     this.countdownSeconds = decoded.exp - now;

  //     if (this.countdownSeconds <= 0) {
  //       this.auth.logout();
  //     }
  //   } catch {
  //     this.auth.logout();
  //   }
  // }
}
