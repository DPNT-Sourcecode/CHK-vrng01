using System.Collections.Generic;
using System.Linq;
using BeFaster.Runner.Exceptions;

namespace BeFaster.App.Solutions.CHK
{
    public static class CheckoutSolution
    {
        private static Dictionary<char, int> SKUs = new Dictionary<char, int>();
        private static readonly char[] knownSKUs = new[] { 'A', 'B', 'C', 'D' };
        public static int ComputePrice(string skus)
        {
            var total = 0;
            var charArr = skus.ToCharArray();
            foreach (var c in charArr)
            {
                if (!knownSKUs.Contains(c))
                {
                    return -1;
                }

                if (SKUs.ContainsKey(c))
                {
                    SKUs.Add(c, 1);
                }
                else
                {
                    SKUs[c] += 1;
                }

                if (SKUs[c].Equals(3) && c.Equals('A'))
                {

                }
                else if (SKUs[c].Equals(2) && c.Equals('B'))
                {

                }
            }
        }
    }
}
