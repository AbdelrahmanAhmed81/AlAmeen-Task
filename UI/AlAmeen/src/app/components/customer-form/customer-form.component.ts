import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Customer } from 'src/app/models/Customer';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  @Input() selectedCustomer: Customer | undefined;

  @Output() onSubmitForm: EventEmitter<FormData> = new EventEmitter<FormData>();
  @Output() onCancelForm: EventEmitter<void> = new EventEmitter<void>();

  customerForm: FormGroup;
  firstNameErrors: errors = {
    required: 'First Name field is required',
  }
  lastNameErrors: errors = {
    required: 'Last Name field is required',
  }
  emailErrors: errors = {
    required: 'Email field is required'
  }
  phoneErrors: errors = {
  }

  constructor() {
    this.customerForm = new FormGroup({
      'firstName': new FormControl(null, [Validators.required]),
      'lastName': new FormControl(null, [Validators.required]),
      'email': new FormControl(null, [Validators.required]),
      'phone': new FormControl(null, [Validators.required]),
      'isActive': new FormControl(null),
    });
  }
  ngOnChanges(changes: SimpleChanges): void {
    if (this.selectedCustomer) {
      this.customerForm.reset();
      this.customerForm.setValue({
        'firstName': this.selectedCustomer.firstName,
        'lastName': this.selectedCustomer.lastName,
        'email': this.selectedCustomer.email,
        'phone': this.selectedCustomer.phone,
        'isActive': this.selectedCustomer.isActive,
      })
    }
  }

  ngOnInit(): void {

  }

  onCancel() {
    this.onCancelForm.emit();
  }

  onSubmit() {
    let formValue = this.customerForm.value;
    let customerData: FormData = new FormData();
    for (const key in formValue) {
      customerData.append(key, formValue[key]);
    }

    if (this.selectedCustomer) {
      customerData.append('customerId', this.selectedCustomer.customerId.toString())
    }

    this.onSubmitForm.emit(customerData);
  }

}
type errors = { [code: string]: string }