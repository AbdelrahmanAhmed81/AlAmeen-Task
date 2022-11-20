import { JsonpClientBackend } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { Customer } from 'src/app/models/Customer';

@Component({
  selector: 'app-customer-form',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerFormComponent implements OnInit {

  @Input() selectedCustomer: Customer | undefined;

  @Output() onSubmitForm: EventEmitter<Customer> = new EventEmitter<Customer>();
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
  // addressLineErrors: errors = {
  //   required: 'address line is required'
  // }

  addressesControls: any;
  constructor() {
    this.customerForm = new FormGroup({
      'firstName': new FormControl(null, [Validators.required]),
      'lastName': new FormControl(null, [Validators.required]),
      'email': new FormControl(null, [Validators.required]),
      'phone': new FormControl(null, [Validators.required]),
      'isActive': new FormControl(true),
      'customerAddresses': new FormArray([])
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
        'customerAddresses': this.selectedCustomer.customerAddresses
      })
    }
  }

  ngOnInit(): void {
    this.addressesControls = (<FormArray>this.customerForm.get('customerAddresses')).controls;
  }

  onCancel() {
    this.onCancelForm.emit();
  }

  onSubmit() {
    let formValue = this.customerForm.value;
    let customer: Customer = {
      firstName: formValue['firstName'],
      lastName: formValue['lastName'],
      email: formValue['email'],
      phone: formValue['phone'],
      isActive: formValue['isActive'],
      customerAddresses: formValue['customerAddresses']
    }

    this.onSubmitForm.emit(customer);
  }

  addAddress() {
    const addressGroup = new FormGroup({
      'addressLine1': new FormControl(null, Validators.required),
      'addressLine2': new FormControl(null, Validators.required),
      'state': new FormControl(null, Validators.required),
      'city': new FormControl(null, Validators.required),
      'country': new FormControl(null, Validators.required),
      'postalCode': new FormControl(null, Validators.required),
      'isShippingAddress': new FormControl(false, Validators.required),
      'isBillingAddress': new FormControl(false, Validators.required),
    });
    (<FormArray>this.customerForm.get('customerAddresses')).push(addressGroup)
  }
  removeAddress(i: number) {
    (<FormArray>this.customerForm.get('customerAddresses')).removeAt(i);
    this.addressesControls = (<FormArray>this.customerForm.get('customerAddresses')).controls;
  }
}
type errors = { [code: string]: string }