import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { HashLocationStrategy, LocationStrategy } from '@angular/common';
import { AppComponent } from './app.component';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { LoginComponent } from './login/login.component';
import { CustomerDataComponent } from './customer-data/customer-data.component';

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'contact', component: ContactComponent },
    { path: 'contactus', redirectTo: 'contact' },
    { path: 'login', component: LoginComponent }
];


@NgModule({
  declarations: [
      AppComponent,
      HomeComponent,
      AboutComponent,
      ContactComponent,
      LoginComponent,
      CustomerDataComponent
  ],
  imports: [
      BrowserModule,
      FormsModule,
      HttpModule,
      RouterModule.forRoot(routes)
  ],
    providers: [
        { provide: LocationStrategy, useClass: HashLocationStrategy }],
    bootstrap: [AppComponent]
})
export class AppModule {
    }


