import { Component, signal, OnInit,ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { AuthService } from './services/auth.service'; // مسیر درست رو چک کن
import { InsertTicketComponent } from './components/insert-ticket/insert-ticket';


@Component({
  selector: 'app-root',
  imports: [RouterOutlet,InsertTicketComponent],
  templateUrl: './app.html',
  styleUrls: ['./app.css'] // درستش کن: styleUrls نه styleUrl
})
export class App implements OnInit {
        @ViewChild(InsertTicketComponent) insertTicketModal!: InsertTicketComponent;
  protected readonly title = signal('ClientApp');

  constructor(private authService: AuthService) {}

  ngOnInit() {
    // شروع بررسی خودکار توکن JWT
    this.authService.startTokenTimer();
  }

    openTicketModal() {
    this.insertTicketModal.show();
  
  }
}
