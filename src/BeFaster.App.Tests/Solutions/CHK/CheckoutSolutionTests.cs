using BeFaster.App.Solutions.CHK;

using NUnit.Framework;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTests
    {
        [TestCase("A", ExpectedResult = 50)]
        public int ComputePrice_Discounted_1A(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

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

        [TestCase("AAAAAAAAA", ExpectedResult = 380)]
        public int ComputePrice_Discounted_5A_3A_1A(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("B", ExpectedResult = 30)]
        public int ComputePrice_Discounted_1B(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("BBB", ExpectedResult = 75)]
        public int ComputePrice_Discounted_3B(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("C", ExpectedResult = 20)]
        public int ComputePrice_Discounted_1C(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("CCC", ExpectedResult = 60)]
        public int ComputePrice_Discounted_3C(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("D", ExpectedResult = 15)]
        public int ComputePrice_Discounted_1D(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("DDD", ExpectedResult = 45)]
        public int ComputePrice_Discounted_3D(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("E", ExpectedResult = 40)]
        public int ComputePrice_Discounted_1E(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("EEB", ExpectedResult = 80)]
        public int ComputePrice_Discounted_2E_1B(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("EEBB", ExpectedResult = 110)]
        public int ComputePrice_Discounted_2E_2B(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("ABCD", ExpectedResult = 115)]
        public int ComputePrice_NoDiscount(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("F", ExpectedResult = 10)]
        public int ComputePrice_Fail_1F(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("FFF", ExpectedResult = 10)]
        public int ComputePrice_Fail_3F(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("FFFFF", ExpectedResult = 40)]
        public int ComputePrice_Fail_5F(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("ABCDEFG", ExpectedResult = -1)]
        public int ComputePrice_Fail_Invalid_SKU(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase(null, ExpectedResult = 0)]
        public int ComputePrice_Fail_InvalidInput(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("AAAAAEEBAAABB", ExpectedResult = 455)]
        public int ComputePrice_Fail_Special1(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }

        [TestCase("ABCDECBAABCABBAAAEEAA", ExpectedResult = 665)]
        public int ComputePrice_Fail_Special2(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }
    }
}

