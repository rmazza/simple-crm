import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomerService } from '../services/customer/customer.service';
import { Customer } from '../entities/customer';

import { GraphqlService } from '../services/grahql/graphql.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
  providers: [CustomerService]
})
export class CustomersComponent implements OnInit {
  pageHeader: string = "CUSTOMERS";
  selectedCustomer: Customer;
  customers: Customer[];

  constructor(
    private customerService: CustomerService,
    private graphqlService: GraphqlService) { }

  ngOnInit() {
    this.graphqlService.sendQuery(`{
      customers {
          id
          firstName
          middleName
          lastName
      }
  }`).subscribe(results => {
    this.customers = results.data.customers;
  });

  }
}
