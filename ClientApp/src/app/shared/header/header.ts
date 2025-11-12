import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { Router } from '@angular/router';
declare var bootstrap: any;
@Component({
  selector: 'app-header',
  templateUrl: './header.html',
  imports: [],
  styleUrls: ['./header.css'] ,
   standalone: true 
})
export class HeaderComponent implements OnInit {

      
  user: any;
 dropdownOpen = false;
  constructor(private authService: AuthService,private router: Router) {}

  ngOnInit(): void {
    this.user = this.authService.getUserInfo();
  }

    logout() {
    this.authService.logout();
  }

 
  openTicketModal() {
    // Modal در AppComponent قرار دارد، فقط با ID بازش می‌کنیم
    const modalEl = document.getElementById('insertTicketModal');
    const modal = new bootstrap.Modal(modalEl, { backdrop: true, keyboard: true });
    modal.show();
  }

    toggleDropdown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  closeDropdown() {
    this.dropdownOpen = false;
  }
}
