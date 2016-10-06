using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using EQ_Dev.Classes;
using EQ_Dev.Enums;
using System.Windows.Input;
using EQ_Dev.Commands;

namespace EQ_Dev.ViewModels
{
    public class MyFundViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<MyStock> _stocks;
        private MyStock _newStockToMyFund;
        private StocksByTypeSummary _equitiesSummary;
        private StocksByTypeSummary _bondsSummary;
        private StocksByTypeSummary _summary;

        public List<TypeOfStock> AvailableTypes { get; set; }

        public MyStock NewStockToMyFund {
            get
            { return _newStockToMyFund; }
            set
            {
                _newStockToMyFund = value;
                OnPropertyChanged("NewStockToMyFund");
            }
        }        

        public ObservableCollection<MyStock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                OnPropertyChanged("Stocks");
            }
        }

        public StocksByTypeSummary EquitiesSummary
        {
            get { return _equitiesSummary; }
            set
            {
                _equitiesSummary = value;
                OnPropertyChanged("EquitiesSummary");
            }
        }

        public StocksByTypeSummary BondsSummary
        {
            get { return _bondsSummary; }
            set
            {
                _bondsSummary = value;
                OnPropertyChanged("BondsSummary");
            }
        }

        public StocksByTypeSummary Summary
        {
            get { return _summary; }
            set
            {
                _summary = value;
                OnPropertyChanged("Summary");
            }
        }

        public ICommand BuyButtonCommand { get; private set; }

        public int EquityCounter { get; set; }
        public int BondCounter { get; set; }

        public bool CanExecute;

        public MyFundViewModel()
        {
            LoadData();
            AvailableTypes = new List<TypeOfStock> {TypeOfStock.Bond, TypeOfStock.Equity};
            BuyButtonCommand = new BuyStockCommand(this);
            NewStockToMyFund = new MyStock();
            NewStockToMyFund.PropertyChanged += CheckBuyingIsPossibile;
        }

        private void CheckBuyingIsPossibile(object sender, PropertyChangedEventArgs e)
        {
            if (NewStockToMyFund.Price > 0 && NewStockToMyFund.Quantity > 0)
            {
                CanExecute = true;
                OnPropertyChanged("CanExecute");
            }
            else
            {
                CanExecute = false;
            }
        }

        private void LoadData()
        {
            Stocks = new ObservableCollection<MyStock>();
            EquitiesSummary = new StocksByTypeSummary();
            BondsSummary = new StocksByTypeSummary();
            Summary = new StocksByTypeSummary();

            GenerateFewSampleStocks();
            UpdateSummaryPanel();
        }

        private void UpdateSummaryPanel()
        {
            ClearSummaryInformation(EquitiesSummary);
            var allEquities = Stocks.Where(i => i.Type == TypeOfStock.Equity);
            UpdateSummaryType(allEquities, EquitiesSummary);

            ClearSummaryInformation(BondsSummary);
            var allBonds = Stocks.Where(i => i.Type == TypeOfStock.Bond);
            UpdateSummaryType(allBonds, BondsSummary);

            ClearSummaryInformation(Summary);
            UpdateSummaryType(Stocks, Summary);

        }

        private void UpdateSummaryType(IEnumerable<MyStock> stocks, StocksByTypeSummary typeOfSummary)
        {
            foreach (var equity in stocks)
            {
                typeOfSummary.TotalNumber++;
                typeOfSummary.TotalMarketValue += equity.MarketValue;
                typeOfSummary.TotalStockWeight += equity.StockWeight;
            }
        }

        private static void ClearSummaryInformation(StocksByTypeSummary summary)
        {
            summary.TotalNumber = 0;
            summary.TotalMarketValue = 0;
            summary.TotalStockWeight = 0;
        }

        internal void AddStockToMyFund()
        {
            FillMissingInformationInNewStock();

            Stocks.Add(NewStockToMyFund);

            RecalculateMarketValue();

            UpdateSummaryPanel();

            NewStockToMyFund.PropertyChanged -= CheckBuyingIsPossibile;

            NewStockToMyFund = new MyStock();
            NewStockToMyFund.PropertyChanged += CheckBuyingIsPossibile;
            NewStockToMyFund.Price = 0m;
            NewStockToMyFund.Quantity = 0;
        }

        private void FillMissingInformationInNewStock()
        {
            NewStockToMyFund.TransactionCost = CountTransationCost(NewStockToMyFund.Type, NewStockToMyFund.Price, NewStockToMyFund.Quantity);
            NewStockToMyFund.Name = GenarateStockName(NewStockToMyFund.Type);
            NewStockToMyFund.MarketValue = NewStockToMyFund.Price*NewStockToMyFund.Quantity;
        }

        private string GenarateStockName(TypeOfStock type)
        {
            return type.ToString() + (type == TypeOfStock.Bond ? BondCounter : EquityCounter);
        }

        private decimal CountTransationCost(TypeOfStock type, decimal price, int quantity)
        {
            decimal transationCost;
            if (type == TypeOfStock.Bond)
            {
                transationCost = decimal.Round(price * quantity * 0.02m, 2);
                BondCounter++;
            }
            else
            {
                transationCost = decimal.Round(price * quantity * 0.005m, 2);
                EquityCounter++;
            }
            return transationCost;
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

                var stock = new MyStock
                {
                    Type = type,
                    TransactionCost = CountTransationCost(type, price, randQuantity),
                    Name = GenarateStockName(type),
                    Price = price,
                    Quantity = randQuantity,
                    MarketValue = price*randQuantity
                };
                Stocks.Add(stock);
            }
            RecalculateMarketValue();
        }

        private void RecalculateMarketValue()
        {
            var totalMarketValue = Stocks.Sum(stock => stock.MarketValue);

            foreach (var stock in Stocks)
            {
                stock.StockWeight = decimal.Round(stock.MarketValue/totalMarketValue*100, 2);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}