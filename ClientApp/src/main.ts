import { bootstrapApplication } from '@angular/platform-browser';
import { App } from './app/app';
import { provideHttpClient } from '@angular/common/http';
import { provideRouter } from '@angular/router';
import { routes } from './app/app.routes';

bootstrapApplication(App, {
  providers: [
    provideHttpClient(),            // جایگزین HttpClientModule
    provideRouter(routes)           // جایگزین RouterModule.forRoot(routes)
  ]
})
.catch(err => console.error(err));
