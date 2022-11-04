import { Customer } from "./Customer";
import { OrderDetail } from "./OrderDetail";

export interface Order {
    orderId: number;
    status: string;
    date: string;
    tax: number;
    subtotal: number;
    total: number;
    customerId: number;
    customer: Customer;
    orderDetails: OrderDetail[];
}