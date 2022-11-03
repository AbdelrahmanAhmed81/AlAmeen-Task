﻿namespace Domain.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price{ get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }
    }
}