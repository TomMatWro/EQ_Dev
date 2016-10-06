using System.Text.RegularExpressions;
using System.Timers;
using System.Windows.Input;
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

        private void PreviewTectInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
