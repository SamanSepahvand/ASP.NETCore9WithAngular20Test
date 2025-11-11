import { Component, signal, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './services/auth.service'; // مسیر درست رو چک کن

@Component({
  selector: 'app-root',
  imports: [RouterOutlet],
  templateUrl: './app.html',
  styleUrls: ['./app.css'] // درستش کن: styleUrls نه styleUrl
})
export class App implements OnInit {
  protected readonly title = signal('ClientApp');

  constructor(private authService: AuthService) {}

  ngOnInit() {
    // شروع بررسی خودکار توکن JWT
    this.authService.startTokenTimer();
  }
}
