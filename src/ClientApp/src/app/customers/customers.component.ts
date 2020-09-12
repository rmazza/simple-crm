import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

import { Customer } from '../entities/customer';
import { GraphqlService } from '../services/grahql/graphql.service';
import { LazyLoadEvent } from 'primeng/api';
import { ConfirmationService } from 'primeng/api';
import { Queries } from '../entities/queries';

const customerQuery: string = `{
  customers {
      id
      userId
      firstName
      lastName
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
  cols: any[];
  datasource: Customer[];
  totalRecords: number;
  loading: boolean;

  constructor(
    private graphqlService: GraphqlService,
    private router: Router,
    private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.graphqlService.sendQuery(customerQuery).subscribe(results => {
      this.datasource = results.data.customers;
      this.totalRecords = results.data.customers.length;
    }, error => {
      console.log(error);
    });
    this.loading = true;
    this.cols = [
      { field: 'userId', header: 'Id'},
      { field: 'firstName', header: 'First' },
      { field: 'lastName', header: 'Last' }
  ];
  }

  public selectCustomer(customer: Customer) {
    this.router.navigate([`/customer/detail/${customer["id"]}`]);
  }

  loadCustomers(event: LazyLoadEvent) {  
    this.loading = true;

    //in a real application, make a remote request to load data using state metadata from event
    //event.first = First row offset
    //event.rows = Number of rows per page
    //event.sortField = Field name to sort with
    //event.sortOrder = Sort order as number, 1 for asc and -1 for dec
    //filters: FilterMetadata object having field as key and filter value, filter matchMode as value

    //imitate db connection over a network
    setTimeout(() => {
        if (this.datasource) {
            this.customers = this.datasource;
            this.loading = false;
        }
    }, 1000);
  }

  confirmDelete(customer: Customer) {
    this.confirmationService.confirm({
        message: 'Are you sure you want to delete this customer?',
        accept: () => {
          let query = Queries.CustomerQueries.mutation.delete(customer["id"]);
          this.graphqlService.sendQuery(query.query, query.variables).subscribe(results => {
            console.log(results);
          }, error => {
            console.log(error);
          });
        }
    });
  }
}
