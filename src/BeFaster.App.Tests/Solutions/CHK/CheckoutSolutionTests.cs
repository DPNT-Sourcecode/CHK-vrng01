using BeFaster.App.Solutions.CHK;

using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTests
    {
        [TestCase("AAAAA", ExpectedResult = 200)]
        public int ComputePrice_Discounted_5A(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("AAA", ExpectedResult = 130)]
        public int ComputePrice_Discounted_3A(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("AAABB", ExpectedResult = 175)]
        public int ComputePrice_Discounted_A_B(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("ABCD", ExpectedResult = 115)]
        public int ComputePrice_NoDiscount(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("ABCDE", ExpectedResult = -1)]
        public int ComputePrice_Fail_Invalid_SKU(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase(null, ExpectedResult = 0)]
        public int ComputePrice_Fail_InvalidInput(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }
    }
}

