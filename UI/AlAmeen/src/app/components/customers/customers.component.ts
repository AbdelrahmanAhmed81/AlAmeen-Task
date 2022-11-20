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
  isLoading: boolean = false;
  customers: Customer[] = [];
  selectedCustomer: Customer | undefined;
  adding: boolean = false;

  constructor(private alertService: AlertService, private customerService: CustomerService) { }

  ngOnInit(): void {
    this.loadCourses();
  }

  loadCourses() {
    this.isLoading = true;
    this.customerService.getAll()
      .subscribe(data => {
        this.customers = data;
        this.isLoading = false;
      })
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

  Submit(customerData: Customer) {
    if (this.adding && !this.selectedCustomer) {
      this.customerService.add(customerData).subscribe(data => {
        this.Cancel();
        this.alertService.showAlert.next({ message: 'Customer Added Succesfully', level: AlertLevel.success });
        this.loadCourses();
      })
    }
    if (this.selectedCustomer && !this.adding) {
      customerData.customerId = this.selectedCustomer.customerId;
      this.customerService.update(customerData).subscribe(data => {
        this.Cancel();
        this.alertService.showAlert.next({ message: 'Changes Saved Succesfully', level: AlertLevel.info });
        this.loadCourses();
      })
    }
  }
}
