import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

import { Customer } from '../entities/customer';
import { GraphqlService } from '../services/grahql/graphql.service';

const customerQuery: string = `{
  customers {
      id
      firstName
      middleName
      lastName
  }
}`;

const addCustomerMutation: string = `{
  mutation ($customer : CustomerInput!) {
    addCustomer(customer : $customer) {
        id
    }
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

  constructor(
    private graphqlService: GraphqlService,
    private formBuilder: FormBuilder) {
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
    }, error => {
      console.log(error);
    });
  }

  onSubmit(customerData: any) {
    var data = { customer: customerData };
    console.log(JSON.stringify(data));
    this.graphqlService.sendQuery(addCustomerMutation, data).subscribe(results => {
      console.log(results);
    }, error => {
      console.log(error);
    });
  }
}
