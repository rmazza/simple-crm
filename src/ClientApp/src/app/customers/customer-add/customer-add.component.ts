import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { MessageService } from 'primeng/api';
import { GraphqlService } from '../../services/grahql/graphql.service';

const addCustomerMutation: string = `
  mutation ($customer:CustomerInput!) {
    addCustomer(customer:$customer) {
      userId
    }
  }`;

@Component({
  selector: 'app-customer-add',
  templateUrl: './customer-add.component.html',
  styleUrls: ['./customer-add.component.css']
})
export class CustomerAddComponent implements OnInit {
  addCustomerForm: FormGroup;

  constructor(
    private graphqlService: GraphqlService,
    private formBuilder: FormBuilder,
    private router: Router,
    private messageService: MessageService) {
      this.addCustomerForm = this.formBuilder.group({
        firstName: '',
        middleName: '',
        lastName: '',
        dateOfBirth: ''
      });
    }

  ngOnInit(): void {
  }

  onSubmit(customerData: any) {
    var data = { customer: customerData };

    this.graphqlService.sendQuery(addCustomerMutation, data).subscribe(results => {
      this.messageService.add({
        severity:'success', 
        summary:'Customer Added', 
        detail:`Id: ${ results.data.addCustomer.userId }`});
      this.router.navigate(['/customers']);
    }, error => {
      console.log(error);
    });
  }

}
