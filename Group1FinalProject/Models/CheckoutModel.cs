using System.ComponentModel.DataAnnotations;
namespace Group1FinalProject.Models
{
    public class CheckoutModel : CartModel
    {
        public double? shipping = 0.0;

        public double? Shipping
        {
            get { return shipping; }
            set { shipping = value; }
        }

        [RegularExpression(@"[0-9]{15,16}", ErrorMessage = "Credit card number isn't in the correct format")]
        public string? CardNumber { get; set; }

        public string? NameOnCard { get; set; }

        [RegularExpression(@"(0[1-9]|10|11|12)/20[0-9]{2}$", ErrorMessage = "Expiration date should be in format MM/YYYY")]
        public string? ExpirationDate { get; set; }

        public Boolean? Success { get; set; }

        public string? ErrorMessage { get; set; }

        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //prints prices with two decimal places
        public double? Taxes
        {
            get { return CalculateTaxes(); }
            set { Taxes = value; }
        }

        public double? CalculateTaxes()
        {
            double? taxes = Subtotal * 0.055;

            return taxes;
        }

        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //prints prices with two decimal places
        public double? Subtotal
        {
            get { return CalculateSubtotal(); }
            set { Subtotal = value; }
        }
        public double CalculateSubtotal()
        {
            double total = 0.0;

            foreach (CartItemModel i in CartItems)
            {
                total += i.CalculateProductsPrice();
            }

            return total;
        }
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //prints prices with two decimal places
        public new double? Total
        {
            get { return CalculateTotal(); }
            set { Total = value; }
        }
        public new double CalculateTotal()
        {
            return (double)(Subtotal + Taxes + Shipping);
        }
    }
}
