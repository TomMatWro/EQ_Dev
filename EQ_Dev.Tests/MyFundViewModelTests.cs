using EQ_Dev.Classes;
using EQ_Dev.Enums;
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
            //arrange
            var sut = new MyFundViewModel();
            //act
            //assert
            Assert.AreEqual(10, sut.Stocks.Count);
        }
        [TestMethod]
        public void StocksCollectionIsGrowingAfterAddNewStock()
        {
            //arrange
            var sut = new MyFundViewModel();
            var newStock = new MyStock
            {
                Name = "aaa",
                Type = TypeOfStock.Equity,
                Price = 20.55m,
                Quantity = 10,
                MarketValue = 20m,
                TransactionCost = 20m,
                StockWeight = 20m
            };

            //act
            sut.Stocks.Add(newStock);
            //assert
            Assert.AreEqual(11, sut.Stocks.Count);
        }

        [TestMethod]
        public void StocksCollectionIsGrowingAfterAddFewNewStocks()
        {
            //arrange
            var sut = new MyFundViewModel();
            var newStock = new MyStock
            {
                Name = "aaa",
                Type = TypeOfStock.Equity,
                Price = 20.55m,
                Quantity = 10,
                MarketValue = 20m,
                TransactionCost = 20m,
                StockWeight = 20m
            };
            //act
            sut.Stocks.Add(newStock);
            sut.Stocks.Add(newStock);
            sut.Stocks.Add(newStock);
            //assert
            Assert.AreEqual(13, sut.Stocks.Count);
        }

        [TestMethod]
        public void AfterAddStockNewStockPriceAndQuantityAre0()
        {
            //arrange
            var sut = new MyFundViewModel();
            var newStock = new MyStock
            {
                Name = "aaa",
                Type = TypeOfStock.Equity,
                Price = 20.55m,
                Quantity = 10,
                MarketValue = 20m,
                TransactionCost = 20m,
                StockWeight = 20m
            };
            //act
            sut.Stocks.Add(newStock);
            sut.Stocks.Add(newStock);
            sut.Stocks.Add(newStock);
            //assert
            Assert.AreEqual(0, sut.NewStockToMyFund.Price);
            Assert.AreEqual(0, sut.NewStockToMyFund.Quantity);
        }
    }
}
