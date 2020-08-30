import { Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';

import { CustomerService } from '../services/customer/customer.service';
import { CustomerDetailComponent } from './customer-detail/customer-detail.component';
import { Customer } from '../entities/customer';
import { Apollo, gql } from 'apollo-angular';

const GET_CUSTOMERS = gql`
{
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
}
`;

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
  providers: [CustomerService]
})
export class CustomersComponent implements OnInit {
  pageHeader: string = "CUSTOMERS";
  customers: Observable<any>;
  selectedCustomer: Customer;

  constructor(private customerService: CustomerService, private apollo: Apollo) { }

  ngOnInit() {
    this.customers = this.apollo
      .watchQuery({
        query: GET_CUSTOMERS,
      })
      .valueChanges.pipe(map(result => result.data && result.data.dogs));
  }
}
