using AutoMoq;
using BeFaster.App.Solutions.CHK;
using Moq;
using NUnit.Framework;
using System;

namespace BeFaster.App.Tests.Solutions.CHK
{
    [TestFixture]
    public class CheckoutSolutionTests
    {
        [TestCase("AAABC", ExpectedResult = 180)]
        public int ComputePrice(string skus)
        {
            return CheckoutSolution.ComputePrice(skus);
        }
    }
}
