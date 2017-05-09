using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1.Main
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand AddNewDebtor { get; set; }

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

        public MainViewModel()
        {
            AddNewDebtor = new Command(AddDebtorHandler);
        }

        private void AddDebtorHandler(object obj)
        {
            
        }
    }
}
