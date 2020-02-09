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
        [TestCase(1, 1, ExpectedResult = 2)]
        public int ComputePrice(int x, int y)
        {
            return CheckoutSolution.ComputePrice(x, y);
        }
    }
}