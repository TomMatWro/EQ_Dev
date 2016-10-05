using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using EQ_Dev.Annotations;
using EQ_Dev.Classes;

namespace EQ_Dev.Models
{
    public class MyFund : INotifyPropertyChanged
    {
        private readonly ObservableCollection<MyStock> _myFundCollection;
        public ObservableCollection<MyStock> MyFundCollection => _myFundCollection;

        public MyFund()
        {
            _myFundCollection = new ObservableCollection<MyStock>();
            _myFundCollection.CollectionChanged += MyFundCollectionChanged;
        }

        private void MyFundCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged("MyFundCollection");
        }


        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}