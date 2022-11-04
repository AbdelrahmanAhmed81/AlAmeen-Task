import { CustomerAddress } from "./CustomerAddress";
import { Order } from "./Order";

export interface Customer {
    customerId: number;
    code: string;
    firstName: string;
    lastName: string;
    email: string;
    phone: string | null;
    isActive: boolean;
    orders: Order[];
    customerAddresses: CustomerAddress[];
}