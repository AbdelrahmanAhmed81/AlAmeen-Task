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

  update(customerData: FormData): Observable<any> {
    return this.http.put(this.url, customerData);
  }

  add(customerData: FormData): Observable<any> {
    return this.http.post(this.url, customerData);
  }
}
