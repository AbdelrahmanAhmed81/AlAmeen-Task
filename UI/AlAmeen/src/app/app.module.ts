import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './components/nav-menu/nav-menu.component';
import { LoadingSpinnerComponent } from './components/loading-spinner/loading-spinner.component';
import { CustomersComponent } from './components/customers/customers.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomerFormComponent } from './components/customer-form/customer-form.component';
import { PagesNavigatorComponent } from './components/pages-navigator/pages-navigator.component';
import { AlertComponent } from './components/alert/alert.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    LoadingSpinnerComponent,
    CustomersComponent,
    CustomerFormComponent,
    PagesNavigatorComponent,
    AlertComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
