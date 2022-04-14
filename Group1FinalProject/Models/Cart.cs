using System.Xml.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Group1FinalProject.Models
{
    public class Cart
    {
        public double? total;
        public int CartId { get; set; }
        public IList<CartItem>? CartItems { get; set; }
        public double? Total
        {
            get { return CalculateTotal(); }
            set { total = value; }
        }

        public double CalculateTotal()
        {
            double total = 0.0;

            foreach (CartItem i in this.CartItems)
            {
                total += i.CalculateProductsPrice();
            }

            return total;
        }
    }
}
