import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GraphqlService {

  headers: HttpHeaders = new HttpHeaders().set('Content-Type', 'application/json');

  constructor(private httpClient: HttpClient) { }

  sendQuery(query: string): Observable<any> {
    const body: string = JSON.stringify({ query });
    
    return this.httpClient.post('api/graphql', body, { 
      headers: this.headers,
      withCredentials: true
    });
  }
}
