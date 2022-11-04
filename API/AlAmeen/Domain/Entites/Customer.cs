namespace Domain.Entites
{
    public class Customer
    {
        public Customer()
        {
            Code = Guid.NewGuid().ToString();
        }
        public int CustomerId { get; set; }
        public string Code { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string? Phone { get; set; }
        public bool IsActive { get; set; }

        public IList<Order> Orders { get; set; }
        public IList<CustomerAddress> CustomerAddresses { get; set; }

    }
}