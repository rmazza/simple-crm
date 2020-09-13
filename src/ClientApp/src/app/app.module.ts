import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { TableModule } from 'primeng/table';
import { CalendarModule } from 'primeng/calendar';
import { InputTextModule } from 'primeng/inputtext';
import { ButtonModule } from 'primeng/button';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';
import { ConfirmationService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { TooltipModule } from 'primeng/tooltip';
import { MegaMenuModule } from 'primeng/megamenu';


import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';

import { UsersComponent } from './users/users.component';
import { AddUserComponent } from './users/add-user/add-user.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerDetailComponent } from './customers/customer-detail/customer-detail.component';
import { CustomerAddComponent } from './customers/customer-add/customer-add.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UsersComponent,
    AddUserComponent,
    CustomersComponent,
    CustomerDetailComponent,
    CustomerAddComponent,
    DashboardComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    ApiAuthorizationModule,
    TableModule,
    CalendarModule,
    InputTextModule,
    ButtonModule,
    ToastModule,
    TooltipModule,
    ConfirmDialogModule,
    MegaMenuModule,
    RouterModule.forRoot([
      
      // { path: '', component: DashboardComponent},
      { path: '', redirectTo: 'dashboard', pathMatch: 'full'},
      { path: 'dashboard',  component: DashboardComponent,
        children: [
          { path: 'customers', component: CustomersComponent, canActivate: [AuthorizeGuard]},
          { path: 'customer/detail/:id', component: CustomerDetailComponent, canActivate: [AuthorizeGuard]},
          { path: 'customer/add', component: CustomerAddComponent, canActivate: [AuthorizeGuard]}
        ] },
      {
        path: 'users', component: UsersComponent,
        children: [{
          path: 'add',
          component: AddUserComponent
        }], canActivate: [AuthorizeGuard]
      }
    ])
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    MessageService,
    ConfirmationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
