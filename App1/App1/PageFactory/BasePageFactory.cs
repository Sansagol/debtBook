using DebtBook.EditDebtor;
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
        public ContentPage CreaeteANewDebtorPage()
        {
            DebtorEditorModel model = new DebtorEditorModel();
            DebtorEditorViewModel vm = new DebtorEditorViewModel(model);
            return new DebtorEditorView(vm);
        }
    }
}
