import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

import { Customer } from '../models/Customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  private readonly url: string = 'https://localhost:7297/api/Customer';
  constructor(private http: HttpClient) { }

  getAll(): Observable<Customer[]> {
    return this.http.get<Customer[]>(this.url);
  }

  update(customerData: Customer): Observable<any> {
    return this.http.put(this.url + '/Update', customerData);
  }

  add(customerData: Customer): Observable<any> {
    return this.http.post(this.url + '/Add', customerData);
  }
}
