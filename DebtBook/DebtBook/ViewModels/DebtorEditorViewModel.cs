using DebtBook.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DebtBook.ViewModels
{
    class DebtorEditorViewModel : ViewModelBase
    {
        private DebtorEditorModel _Model = null;
        private Action<string> _MethodToSetName = null;

        private string _DebtorName = string.Empty;
        public string Name
        {
            get { return _DebtorName; }
            set
            {
                if (_DebtorName != value)
                {
                    _DebtorName = value;
                    OnPropertyChanged(nameof(Name));
                    ((Command)AddDebtorCmd).ChangeCanExecute();
                }
            }
        }

        public ICommand AddDebtorCmd { get; set; }

        public DebtorEditorViewModel(DebtorEditorModel model, Action<string> getNameMethod)
        {
            _Model = model ?? throw new ArgumentNullException(nameof(model));
            if (getNameMethod == null)
                throw new ArgumentNullException(nameof(getNameMethod));

            AddDebtorCmd = new Command(AddDebtor, CanAddDebtor);
            _MethodToSetName = getNameMethod;
        }

        private void AddDebtor(object obj)
        {
            _MethodToSetName.Invoke(Name);
        }

        private bool CanAddDebtor(object arg)
        {
            return !string.IsNullOrWhiteSpace(Name);
        }
    }
}
