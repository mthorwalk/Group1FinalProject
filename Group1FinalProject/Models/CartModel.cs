using System.Xml.Schema;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Group1FinalProject.Models
{
    public class CartModel
    {
        public double? total;
        public int? CartId { get; set; }
        public IList<CartItemModel>? CartItems { get; set; }
        public int? numItems = 0;
        
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //prints prices with two decimal places
        public double? Total
        {
            get { return CalculateTotal(); }
            set { total = value; }
        }

        public double CalculateTotal()
        {
            double total = 0.0;

            foreach (CartItemModel i in this.CartItems)
            {
                total += i.ProductsPrice;
            }

            return total;
        }
         
        public int? NumItems
        {
            get { return CountItems(); }
            set { numItems = value; }
        }

        public int CountItems()
        {
            int items = 0;

            foreach (CartItemModel i in this.CartItems)
            {
                items += i.Quantity;
            }

            return items;
        }
    }
}
