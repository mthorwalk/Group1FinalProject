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
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n1}", ApplyFormatInEditMode = true)]
        public double Rating { get; set; }
        
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //this prints prices with two decimal places
        public double Price { get; set; }

        public string SKU { get; set; }

        public string Image { get; set; }
    }
}
