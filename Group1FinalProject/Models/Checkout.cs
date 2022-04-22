namespace Group1FinalProject.Models
{
    public class Checkout
    {
        public double? total;
        public int CheckoutId { get; set; }
        public IList<CartItem>? CheckoutItems { get; set; }

        public double? CalculateTaxes()
        {
            double? taxes = Subtotal * 0.07;

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

            foreach (CartItem i in CheckoutItems)
            {
                total += i.CalculateProductsPrice();
            }

            return total;
        }

        public double? Total
        {
            get { return CalculateSubtotal() + CalculateTaxes(); }
            set { Total = value; }
        }
    }
}
