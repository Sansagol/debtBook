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
        private SelectionItem _AddDebtorItem = null;

        private ObservableCollection<SelectionItem> _Debtors = new ObservableCollection<SelectionItem>();
        public ObservableCollection<SelectionItem> Debtors { get { return _Debtors; } }
        #endregion

        #region Commands
        public ICommand DebtorNameChangedCommand { get; set; }

        public ICommand SelectedItemTappedCommand { get; set; }
        #endregion

        public DebtorsListViewModel(DebtorsListModel model)
        {
            if (model == null)
                throw new ArgumentNullException(nameof(model));

            _Model = model;
            DebtorNameChangedCommand = new Command(DebtorNameChangedHandler);
            SelectedItemTappedCommand = new Command(SelectedItemTaped);

            _AddDebtorItem = new SelectionItem()
            {
                Title = "Add new debtor",
                CommandHandler = delegate
                {
                    CreateNewDebtor();
                }
            };
        }

        private void DebtorNameChangedHandler(object obj)
        {
            _Debtors.Clear();
            List<Debtor> debtors = _Model.GetDebtorsByName(SelectedDebtorName);
            foreach (var deb in debtors)
            {
                SelectionItem item = new SelectionItem()
                {
                    SourceObject = deb,
                    Title = deb.Name
                };
                _Debtors.Add(item);
            }
        }

        private void SelectedItemTaped(object obj)
        {

        }

        private void CreateNewDebtor()
        {
        }
    }
}
