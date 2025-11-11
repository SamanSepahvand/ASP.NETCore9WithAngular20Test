import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { RegisterComponent } from './pages/register/register';
import { DashboardComponent } from './pages/dashboard/dashboard';
import { AuthGuard } from './guards/auth.guard';
import { MainLayoutComponent } from './layout/main-layout/main-layout';
import { TestPageComponent } from './pages/test-page/test-page';

export const routes: Routes = [
  { path: '', redirectTo: '/login', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'register', component: RegisterComponent },
 {
    path: '',
    component: MainLayoutComponent,
    canActivate: [AuthGuard],
    children: [
      { path: 'dashboard', component: DashboardComponent },
      // سایر صفحات بعدی هم اینجا اضافه می‌کنی
      { path: 'test', component: TestPageComponent }, // حالا هدر و فوتر مشترک
      // { path: 'reports', component: ReportsComponent },
    ],
  },

  { path: '**', redirectTo: '/login' },
];