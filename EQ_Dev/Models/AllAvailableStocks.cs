using System;
using EQ_Dev.Enums;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Timers;

namespace EQ_Dev.Models
{
    public class AllAvailableStocks : INotifyPropertyChanged
    {
        private Random _random ;
        private ObservableCollection<Stock> _allStocksCollection;

        public ObservableCollection<Stock> AllStocksCollection { get { return _allStocksCollection; } }

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        public AllAvailableStocks()
        {
            _random = new Random();
            _allStocksCollection = new ObservableCollection<Stock>();
            _allStocksCollection.CollectionChanged += StocksCollectionChanged;
            GenerateAllStocksCollection();
            StartTimer();
        }

        private void StocksCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("AllStocksCollection");
        }

        private void GenerateAllStocksCollection()
        {
            AllStocksCollection.Add(new Stock { Name = "Equity", Type = TypeOfStock.Equity, Price = 0.4m });
            AllStocksCollection.Add(new Stock { Name = "Equity", Type = TypeOfStock.Equity, Price = 1.9m });
            AllStocksCollection.Add(new Stock { Name = "Equity", Type = TypeOfStock.Equity, Price = 11m });
            AllStocksCollection.Add(new Stock { Name = "Equity", Type = TypeOfStock.Equity, Price = 245.25m });
            AllStocksCollection.Add(new Stock { Name = "Bond", Type = TypeOfStock.Bond, Price = 4m });
            AllStocksCollection.Add(new Stock { Name = "Bond", Type = TypeOfStock.Bond, Price = 6.11m });

        }
        private void StartTimer()
        {
            var _timer = new Timer(5000);
            _timer.Elapsed += GenerateNewPrices;
            _timer.Enabled = true; // Enable it
        }

        public void GenerateNewPrices(object sender, ElapsedEventArgs e)
        {
            foreach (var stock in AllStocksCollection)
            {
                var shouldChange = _random.NextDouble();
                var operation = _random.NextDouble();
                var randomValue = _random.NextDouble();
                if (shouldChange < 0.9)                 //random decission price should be update
                    continue;
                if (operation < 0.5 && (stock.Price > (decimal)randomValue))
                {
                    stock.Price -= (decimal)randomValue;
                    OnPropertyChanged("Price");
                }
                else
                {
                    stock.Price += (decimal)randomValue;
                }
            }
        }
    }
}