using System.ComponentModel;
using System.Runtime.CompilerServices;
using EQ_Dev.Annotations;

namespace EQ_Dev.Classes
{
    public class StocksByTypeSummary : INotifyPropertyChanged
    {
        private int _totalNumber;
        private decimal _totalMarketValue;
        private decimal _totalStockWeight;

        public int TotalNumber
        {
            get
            {
                return _totalNumber;
            }
            set
            {
                _totalNumber = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalMarketValue
        {
            get
            {
                return _totalMarketValue;
            }
            set
            {
                _totalMarketValue = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalStockWeight
        {
            get
            {
                return _totalStockWeight;
            }
            set
            {
                _totalStockWeight = value;
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