import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CurrencyComponent } from '../components/currency.component';
import { CurrencyService } from '../services/currencies/currency.service';
import { provideHttpClient } from '@angular/common/http';

import { FormsModule, NgControl }   from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    CurrencyComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [provideHttpClient(), CurrencyService],
  bootstrap: [AppComponent]
})
export class AppModule { }
