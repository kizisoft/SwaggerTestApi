namespace WebApplication1.Models
{
    public class Customer
    {
        public string CustomerID { get; set; }

        public string CompanyName { get; set; }

        public string ContactName { get; set; }

        public string ContactTitle { get; set; }

        public string Cddress { get; set; }

        public Address Address { get; set; }
    }
}
