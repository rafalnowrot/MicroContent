namespace MicroContent.CompanyProduct.API.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
