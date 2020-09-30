using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class ShoppingCartModel
    {

        public delegate void MentionDiscount(decimal subTotal);

        public List<ProductModel> Items { get; set; } = new List<ProductModel>();
        
        public decimal GenerateTotal(MentionDiscount mentionSubtotal,
            Func<List<ProductModel>, decimal, decimal> calculateDiscountedTotal,
            Action<string> tellUserWeAreDiscounting)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionSubtotal(subTotal);

            tellUserWeAreDiscounting("We are applying your discount");

            // Note - the following method call returns a decimal which is in turn returned by this statement.
            // It would be possible to capture the value returned and then return that (introducing an intermediate variable
            // but this is un-necessary here in this case

            return calculateDiscountedTotal(Items, subTotal);
        }
    }
}
