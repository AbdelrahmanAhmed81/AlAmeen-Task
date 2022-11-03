namespace Domain.Entites
{
    public class OrderShippingAddress
    {
        public int OrderShippingAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        
        public int OrderId { get; set; }
        public Order Order { get; set; }

    }
}
