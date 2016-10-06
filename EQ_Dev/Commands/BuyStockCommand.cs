using EQ_Dev.ViewModels;
using System;
using System.Windows.Input;

namespace EQ_Dev.Commands
{
    internal class BuyStockCommand : ICommand
    {
        private readonly MyFundViewModel _viewModel;

        public BuyStockCommand(MyFundViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _viewModel.CanExecute;
        }

        public void Execute(object parameter)
        {
            _viewModel.AddStockToMyFund();
        }
    }
}
