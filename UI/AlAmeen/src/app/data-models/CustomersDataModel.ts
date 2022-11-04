import { Customer } from "../models/Customer";

export interface CustomersDataModel {
    customers: Customer[];
    customersCount: number;
}