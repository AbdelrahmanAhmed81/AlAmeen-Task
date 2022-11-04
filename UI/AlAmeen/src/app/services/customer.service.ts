import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { CustomersDataModel } from '../data-models/CustomersDataModel';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private readonly url: string = 'https://localhost:7017/api/Customer';
  constructor(private http: HttpClient) { }

  getAll(params?: HttpParams): Observable<CustomersDataModel> {
    return this.http.get<CustomersDataModel>(this.url, {
      params: params
    });
  }

  update(customerData: FormData): Observable<any> {
    return this.http.put(this.url, customerData);
  }

  add(customerData: FormData): Observable<any> {
    return this.http.post(this.url, customerData);
  }
}
