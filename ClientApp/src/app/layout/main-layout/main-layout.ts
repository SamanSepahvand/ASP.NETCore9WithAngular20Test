import { Component } from '@angular/core';
import { HeaderComponent } from '../../shared/header/header';
import { FooterComponent } from '../../shared/footer/footer';
import { RouterModule } from '@angular/router';


@Component({
  selector: 'app-main-layout',
  standalone: true,
  templateUrl: './main-layout.html',
  styleUrl: './main-layout.css',
  imports: [HeaderComponent, FooterComponent, RouterModule],  // ⚡ حتما اینجا import کن


})
export class MainLayoutComponent {

}
