namespace Group1FinalProject.Models
{
    public class CheckoutModel
    {
        public int CheckoutId { get; set; }
        public IList<CartItemModel>? CheckoutItems { get; set; }

        public double Shipping { get; set; }

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
        public double? Subtotal
        {
            get { return CalculateSubtotal(); }
            set { Subtotal = value; }
        }
        public double CalculateSubtotal()
        {
            double total = 0.0;

            foreach (CartItemModel i in CheckoutItems)
            {
                total += i.CalculateProductsPrice();
            }

            return total;
        }
        [System.ComponentModel.DataAnnotations.DisplayFormat(DataFormatString = "{0:n2}", ApplyFormatInEditMode = true)] //prints prices with two decimal places
        public double? Total
        {
            get { return CalculateTotal(); }
            set { Total = value; }
        }
        public double CalculateTotal()
        {
            return (double)(Subtotal + Taxes + Shipping);
        }
    }
}
