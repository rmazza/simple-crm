import { HttpClient, HttpHeaders } from '@angular/common/http';

export class GraphqlService {

  private API_ENDPOINT: string = "api/graphql";

  constructor(private httpClient: HttpClient) { }

  public sendQuery(query: string, ...vars: any) {
    const body: any  = JSON.stringify({
      query,
      variables: vars
    });

    this.httpClient.post(this.API_ENDPOINT, body, { 
      headers: {
        'Content-Type': 'application/json',
        'Accept': 'application/json',
      }
    }).subscribe(result => {
      console.log(result);
    }, error => console.error(error));;

  }
}
