using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using EQ_Dev.Annotations;
using EQ_Dev.Classes;
using EQ_Dev.Enums;

namespace EQ_Dev.ViewModels
{
    public class MyFundViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MyStock> _stocks;
        public ObservableCollection<MyStock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                OnPropertyChanged();
            }
        }

        public MyFundViewModel()
        {
            LoadData();
        }

        private void LoadData()
        {
            Stocks = new ObservableCollection<MyStock>();
            GenerateFewSampleStocks();
        }

        private void GenerateFewSampleStocks()
        {
            var rand = new Random();
            for (var i = 0; i < 10; i++)
            {
                var randPrice = rand.Next(0, 100);
                var randPriceAfterComma = rand.NextDouble();
                var decPrice = (decimal) (randPrice + randPriceAfterComma);
                var price = (decimal.Round(decPrice, 2));

                var randQuantity = rand.Next(0, 66);

                var randType = rand.NextDouble();
                var type = randType < 0.5 ? TypeOfStock.Equity : TypeOfStock.Bond;
                decimal transactionCost = 0;
                if (type == TypeOfStock.Bond)
                {
                    transactionCost = decimal.Round(price*randQuantity*0.02m, 2);
                    BondCounter++;
                }
                else
                {
                    transactionCost = decimal.Round(price * randQuantity * 0.005m, 2);
                    EquityCounter++;
                }

                var stock = new MyStock
                {
                    Type = type,
                    Name = type.ToString() + ( type == TypeOfStock.Bond ? BondCounter : EquityCounter),
                    Price = price,
                    Quantity = randQuantity,
                    MarketValue = price*randQuantity,
                    TransactionCost = transactionCost
                };
                Stocks.Add(stock);
            }
            var totalMarketValue = Stocks.Sum(stock => stock.MarketValue);

            foreach (var stock in Stocks)
            {
                stock.StockWeight = decimal.Round(stock.MarketValue/totalMarketValue * 100, 2);
            }
        }

        public int EquityCounter { get; set; }
        public int BondCounter { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}