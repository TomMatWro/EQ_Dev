using System.ComponentModel;
using System.Runtime.CompilerServices;
using EQ_Dev.Annotations;
using EQ_Dev.Enums;

namespace EQ_Dev
{
    public class Stock : INotifyPropertyChanged
    {
        public TypeOfStock Type { get; set; }

        public string Name { get; set; }

        private decimal _price;
        public decimal Price { get { return _price; }
            set
            {
                _price = value;
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