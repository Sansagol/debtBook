using DebtBook.Models;
using DebtBook.ViewModels;
using DebtBook.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DebtBook.PageFactory
{
    public class BasePageFactory : IPageFactory
    {
        /// <summary>Create the edit debtor page.</summary>
        /// <returns>Created page.</returns>
        public ContentPage CreaeteANewDebtorPage(Action<string> setNameMethod)
        {
            DebtorEditorModel model = new DebtorEditorModel();
            DebtorEditorViewModel vm = new DebtorEditorViewModel(model, setNameMethod);
            return new DebtorEditorView(vm);
        }
    }
}
