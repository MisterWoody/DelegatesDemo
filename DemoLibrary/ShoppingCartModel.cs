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
        
        public decimal GenerateTotal(MentionDiscount mentionDiscount)
        {
            decimal subTotal = Items.Sum(x => x.Price);

            mentionDiscount(subTotal);
            
            // The following code is brittle and subject to frequent change potentially due ot hard coded values.
            // Let's improve this with a delegate.

            if (subTotal  > 100)
            {
                return subTotal * 0.80M;
            }
            else if (subTotal > 50)
            {
                return subTotal * 0.85M;
            }
            else if (subTotal > 10)
            {
                return subTotal * 0.90M;
            }
            else
            {
                return subTotal;
            }
        }
    }
}
