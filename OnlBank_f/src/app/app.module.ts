import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import {MatToolbarModule} from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatTreeModule} from '@angular/material/tree';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatListModule} from '@angular/material/list';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginAdminFormComponent } from './components/login-admin-form/login-admin-form.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { MainNavigationComponent } from './components/main-navigation/main-navigation.component';
import { CoverComponent } from './components/cover/cover.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterFormComponent,
    LoginAdminFormComponent,
    MainPageComponent,
    MainNavigationComponent,
    CoverComponent
  ],
  imports: [
    MatCardModule,
    MatButtonModule,
    MatListModule,
    MatSidenavModule,
    MatTreeModule,
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
