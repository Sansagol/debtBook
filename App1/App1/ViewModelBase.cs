using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DebtBook
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        private INavigation _Navigator = null;
        public INavigation Navigator
        {
            get { return _Navigator; }
            set
            {
                if (_Navigator != value)
                {
                    _Navigator = value;
                    OnPropertyChanged(nameof(Navigator));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public virtual void OnPropertyChanged(string propertyName)
        {
            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                var e = new PropertyChangedEventArgs(propertyName);
                PropertyChanged?.Invoke(this, e);
            }
        }
    }
}
