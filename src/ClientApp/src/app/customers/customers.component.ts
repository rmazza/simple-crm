import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { Customer } from '../entities/customer';
import { GraphqlService } from '../services/grahql/graphql.service';

const customerQuery: string = `{
  customers {
      id
      firstName
      middleName
      lastName
      emailAddresses {
        id
        type
        email
      }
  }
}`;

const addCustomerMutation: string = `
  mutation ($customer:CustomerInput!) {
    addCustomer(customer:$customer) {
      id
    }
  }`;

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  pageHeader: string = "CUSTOMERS";
  customers: Customer[];
  addCustomerForm: FormGroup;
  cols: any[];

  constructor(
    private graphqlService: GraphqlService,
    private formBuilder: FormBuilder,
    private router: Router) {
      this.addCustomerForm = this.formBuilder.group({
        firstName: '',
        middleName: '',
        lastName: '',
        dateOfBirth: ''
      });
     }

  ngOnInit() {
    this.graphqlService.sendQuery(customerQuery).subscribe(results => {
      this.customers = results.data.customers;
      console.log(this.customers);
    }, error => {
      console.log(error);
    });

    this.cols = [
      { field: 'firstName', header: 'First' },
      { field: 'middleName', header: 'Middle' },
      { field: 'lastName', header: 'Last' },
      { field: 'dateOfBirth', header: 'DOB' }
  ];
  }

  onSubmit(customerData: any) {
    var data = { customer: customerData };

    this.graphqlService.sendQuery(addCustomerMutation, data).subscribe(results => {
      console.log(results);
    }, error => {
      console.log(error);
    });
  }

  public selectCustomer(customer: Customer) {
    this.router.navigate([`/customers/${customer["id"]}`]);
  }
}
