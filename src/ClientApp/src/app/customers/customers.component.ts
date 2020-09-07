import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomerService } from '../services/customer/customer.service';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { Customer } from '../entities/customer';
import { GraphqlService } from '../services/graphql.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
  providers: [CustomerService]
})
export class CustomersComponent implements OnInit {
  pageHeader: string = "CUSTOMERS";
  // customers: Observable<any>;
  selectedCustomer: Customer;

  constructor(
    private customerService: CustomerService,
    private graphqlService: GraphqlService) { }

  ngOnInit() {
    const query = `{
      customers {
          id
          firstName
          middleName
          lastName
          emailAddr {
              id
              type
              email
          }
          phoneNum {
              id
              type
              number
              extension
          }
      }
  }`;

  this.graphqlService.sendQuery(query);
  }
}
