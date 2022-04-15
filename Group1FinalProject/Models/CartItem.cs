using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Group1FinalProject.Models
{
    public class CartItem : Product
    {
        public int quantity = 1;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public double CalculateProductsPrice()
        {
            return Math.Round(this.Quantity * this.Price, 2);
        }
    }
}
