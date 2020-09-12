import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, ParamMap } from '@angular/router';
import { switchMap } from 'rxjs/operators';

import { Customer } from '../../entities/customer';
import { GraphqlService } from '../../services/grahql/graphql.service';

const getCustomer: string =  `
query ($id: ID!) {
  customer(id:$id) {
    id
    firstName
    middleName
    lastName
    dateOfBirth
  }
}`

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

  public customer: Customer;
  public editMode: boolean = false;

  constructor(
    private graphqlService: GraphqlService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this.route.paramMap.pipe(
      switchMap( (params: ParamMap) =>  
        this.graphqlService.sendQuery(getCustomer, { id: params.get('id') })
      )
    ).subscribe(result => { 
      this.customer = result.data.customer;
    });
  }

  public edit(): void {
    this.editMode = !this.editMode;
  }
}
