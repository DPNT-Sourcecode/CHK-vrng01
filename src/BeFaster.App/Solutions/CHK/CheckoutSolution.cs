using System;
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
                        while (val > 0)
                        {
                            if (val >= 5)
                            {
                                var c = CalcIntValue(val, 5);
                                total += c * 200;
                                val -= c;
                            }
                            if (val >= 3)
                            {
                                var c = CalcIntValue(val, 5);
                                total += c * 130;
                                val -= c;
                            }
                            
                        }

                        break;
                    case 'B':
                        break;
                    case 'C':
                    case 'D':
                        break;
                    case 'E':
                        break;
                }
            }

            return total;
        }

        private static int CalcIntValue(int x, int y)
        {
            return Convert.ToInt32(decimal.Truncate(x / y));
        }
    }
}

