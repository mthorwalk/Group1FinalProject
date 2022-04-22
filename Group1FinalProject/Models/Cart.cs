using System.Xml.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Group1FinalProject.Models
{
    public class Cart
    {
        public double? total;
        public int CartId { get; set; }
        public IList<CartItem>? CartItems { get; set; }
        
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //prints prices with two decimal places
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
                total += i.ProductsPrice;
            }

            return total;
        }
    }
}
