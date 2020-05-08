import { Injectable } from '@angular/core';

import { Customer } from '../../entities/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customers: Customer[] = [
    new Customer("Bob", "Mazza", "Andrew"),
    new Customer("Traci", "Mazza", "Hayes")
  ];

  constructor() { }

  getCustomers(): Customer[] {
    return this.customers;
  }
}
