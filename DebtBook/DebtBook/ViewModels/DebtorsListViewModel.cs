using DebtBook.Entities;
using DebtBook.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DebtBook.ViewModels
{
    class DebtorsListViewModel : ViewModelBase
    {
        DebtorsListModel _Model = null;

        #region Properties
        private string _SelectedDebtorName = string.Empty;
        public string SelectedDebtorName
        {
            get { return _SelectedDebtorName; }
            set
            {
                if (_SelectedDebtorName != value)
                {
                    _SelectedDebtorName = value;
                    OnPropertyChanged(nameof(SelectedDebtorName));
                }
            }
        }

        private ObservableCollection<Debtor> _Debtors = new ObservableCollection<Debtor>();
        public ObservableCollection<Debtor> Debtors { get { return _Debtors; } }
        #endregion

        #region Commands
        public ICommand DebtorNameChangedCommand { get; set; }

        public ICommand CreateDebtorCommand { get; set; }
        #endregion

        public DebtorsListViewModel(DebtorsListModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            _Model = model;
            DebtorNameChangedCommand = new Command(DebtorNameChangedHandler);
            CreateDebtorCommand = new Command(CreateDebtor);
        }

        private void DebtorNameChangedHandler(object obj)
        {
            _Debtors.Clear();
            _Model.GetDebtorsByName(SelectedDebtorName).ForEach(dn => _Debtors.Add(dn));
        }

        private void CreateDebtor(object obj)
        {

        }
    }
}
