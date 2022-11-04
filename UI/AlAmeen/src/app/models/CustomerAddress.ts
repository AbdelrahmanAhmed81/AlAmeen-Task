import { Customer } from "./Customer";

export interface CustomerAddress {
    customerAddressId: number;
    addressLine1: string;
    addressLine2: string;
    country: string;
    city: string;
    state: string;
    postalCode: string;
    isShippingAddress: boolean;
    isBillingAddress: boolean;
    customerId: number;
    customer: Customer;
}