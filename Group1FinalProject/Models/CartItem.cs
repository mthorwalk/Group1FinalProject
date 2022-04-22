using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Group1FinalProject.Models
{
    public class CartItem : Product
    {
        public int quantity = 1;
        public double productsPrice;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //prints prices with two decimal places
        public double ProductsPrice
        {
            get { return CalculateProductsPrice(); }
            set { productsPrice = value; }
        }

        public double CalculateProductsPrice()
        {
            return Math.Round(this.Quantity * this.Price, 2);
        }
    }
}
