using System;
using System.Collections.Generic;
using System.Text;

namespace DebtBook.EditDebtor
{
    class DebtorEditorViewModel:ViewModelBase
    {
        private DebtorEditorModel _Model = null;
        public DebtorEditorViewModel(DebtorEditorModel model)
        {
            _Model = model ?? throw new ArgumentNullException(nameof(model));
        }
    }
}
