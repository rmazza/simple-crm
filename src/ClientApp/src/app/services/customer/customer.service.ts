import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { Customer } from '../../entities/customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private customers: Customer[];
  apiUrl: string = '../../../assets/test-customer-data.json';
  headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(
    private httpClient: HttpClient
  ) { }

  //getCustomers(): Observable<Customer[]> {
  //  return this.httpClient.get(this.apiUrl).subscribe(data:  =>
  //    this.customers = data;
  //  )
  //}

  // Handle Errors 
  error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    return throwError(errorMessage);
  }
}
