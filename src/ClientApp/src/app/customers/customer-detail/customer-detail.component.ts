import { Component, OnInit } from '@angular/core';

const updateCustomer: string = `
  mutation ($customer:CustomerInput!) {
    updateCustomer(customer:$customer) {
      id
    }
  }`;

@Component({
  selector: 'app-customer-detail',
  templateUrl: './customer-detail.component.html',
  styleUrls: ['./customer-detail.component.css']
})
export class CustomerDetailComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

}
