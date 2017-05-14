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
    public class MainViewModel : ViewModelBase
    {
        private MainModel _Model = null;

        public ICommand AddNewDebtor { get; set; }
        public ICommand AddDebtorCmd { get; set; }

        private ObservableCollection<Debt> _Debts = new ObservableCollection<Entities.Debt>();
        public ObservableCollection<Debt> Debts { get { return _Debts; } }

        private string _Debtorname = string.Empty;
        public string DebtorName
        {
            get { return _Debtorname; }
            set
            {
                if (_Debtorname != null && !_Debtorname.Equals(value) ||
                    _Debtorname != value)
                {
                    _Debtorname = value;
                    OnPropertyChanged(nameof(DebtorName));
                }
            }
        }

        private int _Debt = 0;
        public int Debt
        {
            get { return _Debt; }
            set
            {
                if (_Debt != value)
                {
                    _Debt = value;
                    OnPropertyChanged(nameof(Debt));
                }
            }
        }

        private int _DebtPersent = 0;
        public int DebtPersent
        {
            get { return _DebtPersent; }
            set
            {
                if (_DebtPersent != value)
                {
                    _DebtPersent = value;
                    OnPropertyChanged(nameof(DebtPersent));
                }
            }
        }

        public MainViewModel(MainModel model)
        {
            _Model = model ?? throw new ArgumentNullException(nameof(model));
            _Model.DebtorNameChanged += _Model_DebtorNameChanged;

            PropertyChanged += MainViewModel_PropertyChanged;

            AddNewDebtor = new Command(AddDebtorHandler);
            AddDebtorCmd = new Command(ShowEditDebtorPage);
        }

        private void _Model_DebtorNameChanged(string obj)
        {
            DebtorName = obj;
        }

        private void MainViewModel_PropertyChanged(
            object sender, 
            System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(Navigator)) && Navigator!=null)
            {
                _Model.Initialize(Navigator);
            }
        }

        private void AddDebtorHandler(object obj)
        {
            if (!string.IsNullOrWhiteSpace(DebtorName) &&
                Debt > 0)
            {
                Debt db = new Entities.Debt()
                {
                    CurrentDebtor = new Debtor() { Name = DebtorName },
                    Value = Debt,
                    Rate = DebtPersent
                };

                Debts.Add(db);
            }
        }

        private void ShowEditDebtorPage(object obj)
        {
            _Model.ShowAddNewDebtor();
        }
    }
}
