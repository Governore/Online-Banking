import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegisterFormComponent } from './components/register-form/register-form.component';
import { LoginFormComponent } from './components/login-form/login-form.component';
import { AppComponent } from './app.component';
import { CoverComponent } from './components/cover/cover.component';
import { LoginAdminFormComponent } from './components/login-admin-form/login-admin-form.component';

const routes: Routes = [
  {
    path: '',
    component: CoverComponent
  },
  {
    path: 'register-form-component',
    component: RegisterFormComponent
  },
  {
    path: 'login-form-component',
    component: LoginFormComponent
  },
  {
    path: 'login-admin-form-component',
    component: LoginAdminFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
