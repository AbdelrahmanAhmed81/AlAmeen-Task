import { Order } from "./Order";
import { Product } from "./Product";

export interface OrderDetail {
    orderDetailId: number;
    quantity: number;
    price: number;
    tax: number;
    total: number;
    productId: number;
    product: Product;
    orderId: number;
    order: Order;
}