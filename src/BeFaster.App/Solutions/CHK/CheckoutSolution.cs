using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        public static int ComputePrice(string skus)
        {
            var SKUs = new Dictionary<char, int>();
            var knownSKUs = new[] { 'A', 'B', 'C', 'D' };

            if (string.IsNullOrEmpty(skus))
            {
                return 0;
            }

            var total = 0;
            var charArr = skus.ToCharArray();
            foreach (var c in charArr)
            {
                if (!knownSKUs.Contains(c))
                {
                    return -1;
                }

                if (!SKUs.ContainsKey(c))
                {
                    SKUs.Add(c, 1);
                }
                else
                {
                    SKUs[c] += 1;
                }
            }

            foreach (var sku in SKUs)
            {
                var key = sku.Key;
                var val = sku.Value;
                switch (key)
                {
                    case 'A':

                        break;
                    case 'B':
                        break;
                    case 'C':
                    case 'D':
                        break;
                    case 'E':
                        break;
                }
                if (key.Equals('A'))
                {
                    //switch (val)
                    //{
                    //    case 
                    //}
                }
                //switch (count)
                //{
                //    case 3 when c.Equals('A'):
                //        total += 130;
                //        SKUs[c] = 0;
                //        break;
                //    case 2 when c.Equals('B'):
                //        total += 45;
                //        SKUs[c] = 0;
                //        break;
                //}
                //switch (sku.Key)
                //{
                //    case 'A':
                //        total += count * 50;
                //        break;
                //    case 'B':
                //        total += count * 30;
                //        break;
                //    case 'C':
                //        total += count * 20;
                //        break;
                //    case 'D':
                //        total += count * 15;
                //        break;
                //}
            }

            return total;
        }
    }
}



