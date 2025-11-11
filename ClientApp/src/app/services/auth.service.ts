import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { jwtDecode } from 'jwt-decode';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private tokenCheckInterval: any;

  constructor(private router: Router) {

  // وقتی سرویس ساخته میشه، چک کن آیا چیزی در localStorage هست یا نه
    const saved = localStorage.getItem('userInfo');
    if (saved) {
      this.userInfo = JSON.parse(saved);
    }

  }

  // داخل AuthService
isLoggedIn(): boolean {
  const token = this.getToken();
  return !!token; // true اگر توکن موجود باشه
}



  // شروع بررسی خودکار توکن هر 5 ثانیه
  startTokenTimer() {
    this.tokenCheckInterval = setInterval(() => this.checkToken(), 5000);
  }

  // توقف بررسی
  stopTokenTimer() {
    if (this.tokenCheckInterval) clearInterval(this.tokenCheckInterval);
  }

  // بررسی اعتبار توکن
  checkToken() {
    const token = localStorage.getItem('jwt');
    if (!token) return this.logout();

    try {
      const decoded: any = jwtDecode(token);
      const now = Math.floor(Date.now() / 1000);

      if (decoded.exp < now) {
        this.logout();
      }
    } catch {
      this.logout();
    }
  }

  // خروج از سیستم
  logout() {
    localStorage.removeItem('jwt');
    this.stopTokenTimer();
    this.router.navigate(['/login']);
  }

  // گرفتن توکن فعلی
  getToken() {
    return localStorage.getItem('jwt');
  }
  decodeToken(token: string) {
  return jwtDecode(token);
}


userInfo: any;

setUserInfo(info: any) {
    this.userInfo = info;
    localStorage.setItem('userInfo', JSON.stringify(info)); // ✅ ذخیره در localStorage
  }

  getUserInfo() {
    if (!this.userInfo) {
      const saved = localStorage.getItem('userInfo');
      if (saved) {
        this.userInfo = JSON.parse(saved);
      }
    }
    return this.userInfo;
  }

  clearUserInfo() {
    this.userInfo = null;
    localStorage.removeItem('userInfo');
  }

}
