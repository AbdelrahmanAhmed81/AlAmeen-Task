namespace Domain.Entites
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public decimal Tax { get; set; }
        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public IList<OrderDetail> OrderDetails { get; set; }

    }
}
