namespace Group1FinalProject.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        
        public int CategoryId { get; set; }

        public string Manufacturer { get; set; }

        public string Description { get; set; }

        public string Dimensions { get; set; }

        public double Weight { get; set; }

        public double Rating { get; set; }

        public double Price { get; set; }

        public string SKU { get; set; }
    }
}
