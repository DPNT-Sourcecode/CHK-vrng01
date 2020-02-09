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

                }
            }
        }
    }
}


