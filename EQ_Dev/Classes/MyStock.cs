using System.ComponentModel;
using System.Runtime.CompilerServices;
using EQ_Dev.Annotations;
using EQ_Dev.Enums;

namespace EQ_Dev.Classes
{
    public class MyStock : INotifyPropertyChanged
    {
        private TypeOfStock _type;
        private string _name;
        private decimal _price;
        private int _quantity;
        private decimal _marketValue;
        private decimal _transactionCost;
        private decimal _stockWeight;


        public TypeOfStock Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                OnPropertyChanged();
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public decimal Price { get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged();
            }
        }

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                OnPropertyChanged();
            }
        }

        public decimal MarketValue
        {
            get { return _marketValue; }
            set
            {
                _marketValue = value;
                OnPropertyChanged();
            }
        }

        public decimal TransactionCost
        {
            get { return _transactionCost; }
            set
            {
                _transactionCost = value;
                OnPropertyChanged();
            }
        }

        public decimal StockWeight
        {
            get { return _stockWeight; }
            set
            {
                _stockWeight = value;
                OnPropertyChanged();
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}