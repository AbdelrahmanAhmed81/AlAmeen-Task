namespace Domain.Entites
{
    public class CustomerAddress
    {
        public int CustomerAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public bool IsShippingAddress { get; set; }
        public bool IsBillingAddress { get; set; }

        public int CustomerId { get; set; }
        public Customer? Customer { get; set; }

    }
}
