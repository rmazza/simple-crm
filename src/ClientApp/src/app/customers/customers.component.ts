import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomerService } from '../services/customer/customer.service';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { Customer } from '../entities/customer';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
  providers: [CustomerService]
})
export class CustomersComponent implements OnInit {
  pageHeader: string = "CUSTOMERS";
  customers: Customer[];
  selectedCustomer: Customer;

  constructor(private customerService: CustomerService) { }

  ngOnInit() {
    this.customers = this.customerService.getCustomers();
  }

  selectCustomer(customer: Customer) { this.selectedCustomer = customer; }

  getJson(): string {
    return JSON.stringify(this.selectedCustomer);
  }
}
