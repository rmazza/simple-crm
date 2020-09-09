import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { VariableAst } from '@angular/compiler';

@Injectable({
  providedIn: 'root'
})
export class GraphqlService {

  headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private httpClient: HttpClient) { }

  sendQuery(q: string, vars: any = null): Observable<any> {
    const body: string = JSON.stringify({ query: q, variables: vars });
    console.log(body);
    return this.httpClient.post('api/graphql', body, { 
      headers: this.headers,
      withCredentials: true
    });
  };

  error(error: HttpErrorResponse) {
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {
      errorMessage = error.error.message;
    } else {
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    console.log(errorMessage);
    // return throwError(errorMessage);
  }
}
