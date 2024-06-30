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
import { MainAdminPageComponent } from './components/main-admin-page/main-admin-page.component';
import { MainAdminNavigationComponent } from './components/main-admin-navigation/main-admin-navigation.component';
import { AdminProfileComponent } from './components/admin-profile/admin-profile.component';
import { CustomerTransactionRequestComponent } from './components/customer-transaction-request/customer-transaction-request.component';
import { CustomerHelpRequestComponent } from './components/customer-help-request/customer-help-request.component';
import { CustomerRevenueComponent } from './components/customer-revenue/customer-revenue.component';
import { CustomerAccountManagementComponent } from './components/customer-account-management/customer-account-management.component';
import { AccountManagementComponent } from './components/account-management/account-management.component';
import { StaffManagerAccountManagementComponent } from './components/staff-manager-account-management/staff-manager-account-management.component';
import {MatTabsModule} from '@angular/material/tabs';
import { BankAccountComponent } from './components/bank-account/bank-account.component';
import { PaymentTransferComponent } from './components/payment-transfer/payment-transfer.component';
import { HistoryComponent } from './components/history/history.component';
import { AddBankAccountComponent } from './components/add-bank-account/add-bank-account.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { HomeSectionComponent } from './components/home-section/home-section.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { CustomerProfileComponent } from './components/customer-profile/customer-profile.component';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatStepperModule} from '@angular/material/stepper';
import {MatFormFieldModule} from '@angular/material/form-field';
import { ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { TestTableRowSelectedComponent } from './testcomponents/test-table-row-selected/test-table-row-selected.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginFormComponent,
    RegisterFormComponent,
    LoginAdminFormComponent,
    MainPageComponent,
    MainNavigationComponent,
    CoverComponent,
    MainAdminPageComponent,
    MainAdminNavigationComponent,
    AdminProfileComponent,
    CustomerTransactionRequestComponent,
    CustomerHelpRequestComponent,
    CustomerRevenueComponent,
    CustomerAccountManagementComponent,
    AccountManagementComponent,
    StaffManagerAccountManagementComponent,
    BankAccountComponent,
    PaymentTransferComponent,
    HistoryComponent,
    AddBankAccountComponent,
    DashboardComponent,
    HomeSectionComponent,
    ContactUsComponent,
    CustomerProfileComponent,
    TestTableRowSelectedComponent
  ],
  imports: [
    BsDropdownModule.forRoot(),
    ReactiveFormsModule,
    MatFormFieldModule,
    MatStepperModule,
    MatPaginatorModule,
    MatCardModule,
    MatTabsModule,
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
