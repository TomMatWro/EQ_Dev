using System;
using EQ_Dev.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EQ_Dev.Tests
{
    [TestClass]
    public class AllAvailableStocksTests
    {
        [TestMethod]
        public void AfterCreationAllAvailableStocksCollectionHas6Items()
        {
            var sut = new AllAvailableStocks();
            Assert.AreEqual(6,sut.AllStocksCollection.Count);
        }

    }
}
