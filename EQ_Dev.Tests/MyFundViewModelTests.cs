using System;
using EQ_Dev.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EQ_Dev.Tests
{
    [TestClass]
    public class MyFundViewModelTests
    {
        [TestMethod]
        public void ThereAre10SampleStockAfterCreation()
        {
            var sut = new MyFundViewModel();
            Assert.AreEqual(10, sut.Stocks.Count);
        }

    }
}
