import { HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Customer } from 'src/app/models/Customer';
import { AlertLevel, AlertService } from 'src/app/services/alert.service';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent implements OnInit {
  pageNumber: number = 1;
  pageCapacity: number = 10;
  queryParams: HttpParams = new HttpParams()
    .append('pageNumber', this.pageNumber)
    .append('pageCapacity', this.pageCapacity);

  isLoading: boolean = false;
  customers: Customer[] = [];

  totalCustomers: number = 0;

  searchText: string = '';

  selectedCustomer: Customer | undefined;
  adding: boolean = false;
  constructor(private alertService: AlertService, private customerService: CustomerService) { }

  ngOnInit(): void {
  }

  loadCourses() {
    this.isLoading = true;
    this.customerService.getAll(this.queryParams)
      .subscribe(data => {
        this.customers = data.customers;
        this.totalCustomers = data.customersCount
        this.isLoading = false;
      })
  }

  searchTextInput(e: Event) {
    let value: string = (<HTMLInputElement>e.target).value;
    this.queryParams = this.queryParams.set('searchText', value)
    this.loadCourses()
  }

  onChangePagination(data: { pageNumber: number, pageCapacity: number }) {
    this.queryParams = this.queryParams.set('pageNumber', data.pageNumber);
    this.queryParams = this.queryParams.set('pageCapacity', data.pageCapacity);
    this.loadCourses();
  }

  onClickEdit(customer: Customer) {
    this.adding = false
    this.selectedCustomer = customer;
  }

  onClickAdd() {
    this.adding = true;
    this.selectedCustomer = undefined;
  }

  Cancel() {
    this.adding = false;
    this.selectedCustomer = undefined;
  }

  Submit(courseData: FormData) {
    if (this.adding && !this.selectedCustomer) {
      this.customerService.add(courseData).subscribe(data => {
        this.Cancel();
        this.alertService.showAlert.next({ message: 'Course Added Succesfully', level: AlertLevel.success });
        this.loadCourses();
      })
    }
    if (this.selectedCustomer && !this.adding) {
      courseData.append('customerId', this.selectedCustomer.customerId.toString());
      this.customerService.update(courseData).subscribe(data => {
        this.Cancel();
        this.alertService.showAlert.next({ message: 'Changes Saved Succesfully', level: AlertLevel.info });
        this.loadCourses();
      })
    }
  }
}
