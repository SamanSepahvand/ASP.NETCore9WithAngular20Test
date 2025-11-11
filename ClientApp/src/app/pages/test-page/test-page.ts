import { Component } from '@angular/core';
import { HeaderComponent } from '../../shared/header/header';
import { FooterComponent } from '../../shared/footer/footer';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-test-page',
  standalone: true,
  imports: [CommonModule, HeaderComponent, FooterComponent],
  templateUrl: './test-page.html',
  styleUrl: './test-page.css',
})
export class TestPageComponent  {

}
