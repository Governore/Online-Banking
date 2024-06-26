import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MainNavbarComponent } from './components/main-navbar/main-navbar.component';
import { MainUserInfoComponent } from './components/main-user-info/main-user-info.component';
import { SideListFeatureComponent } from './components/side-list-feature/side-list-feature.component';
import { TransactionHistoryComponent } from './components/transaction-history/transaction-history.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon'

@NgModule({
  declarations: [
    AppComponent,
    MainNavbarComponent,
    MainUserInfoComponent,
    SideListFeatureComponent,
    TransactionHistoryComponent
  ],
  imports: [
    MatIconModule,
    MatToolbarModule,
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
