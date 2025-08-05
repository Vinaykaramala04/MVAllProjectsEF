namespace CodeFirstDay2.Models
{
    public class Product
    {
        public int ProductId { get; set; } // PK
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }

    public class Customer
    {
        public int CustomerId { get; set; } // PK
        public string FullName { get; set; }
        public string Email { get; set; }
        public string City { get; set; }
    }

}
