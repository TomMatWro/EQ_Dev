using System.Timers;
using EQ_Dev.Enums;
using EQ_Dev.Models;

namespace EQ_Dev.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        public MainWindow()
        {
            InitializeComponent();
            allStocksCollecton.ItemsSource = new AllAvailableStocks().AllStocksCollection;
        }

    }
}
