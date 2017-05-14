using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DebtBook.PageFactory
{
    public interface IPageFactory
    {
        ContentPage CreaeteANewDebtorPage(Action<string> setNameMethod);
    }
}
