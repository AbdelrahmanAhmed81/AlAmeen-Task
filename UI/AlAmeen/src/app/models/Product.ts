import { OrderDetail } from "./OrderDetail";

export interface Product {
    productId: number;
    name: string;
    description: string | null;
    price: number;
    orderDetails: OrderDetail[];
}