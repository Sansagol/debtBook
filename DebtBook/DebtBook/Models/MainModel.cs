using DebtBook.Entities;
using DebtBook.PageFactory;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DebtBook.Models
{
    public class MainModel
    {
        private INavigation _Navigation = null;
        private IPageFactory _PagesFactory = null;

        public event Action<string> DebtorNameChanged;

        public MainModel(IPageFactory pageFactory)
        {
            _PagesFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
        }

        public void Initialize(INavigation navigation)
        {
            _Navigation = navigation ?? throw new ArgumentNullException(nameof(navigation));
        }

        public void ShowAddNewDebtor()
        {
            var page = _PagesFactory.CreaeteANewDebtorPage(SetDebtorName);
            _Navigation.PushAsync(page);
        }

        private void SetDebtorName(string obj)
        {
            DebtorNameChanged?.Invoke(obj);
        }

        public void ShowEditDebtor(Debtor debtor)
        {
        }
    }
}
