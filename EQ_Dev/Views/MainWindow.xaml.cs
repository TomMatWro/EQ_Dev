using System.Timers;
using EQ_Dev.Enums;
using EQ_Dev.ViewModels;
using MahApps.Metro.Controls;

namespace EQ_Dev.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MyFundViewModel();
        }

    }
}
