import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.html',
  styleUrls: ['./header.css'] ,
   standalone: true 
})
export class HeaderComponent implements OnInit {
  user: any;
 dropdownOpen = false;
  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.user = this.authService.getUserInfo();
  }

    logout() {
    this.authService.logout();
  }



    toggleDropdown() {
    this.dropdownOpen = !this.dropdownOpen;
  }

  closeDropdown() {
    this.dropdownOpen = false;
  }
}
