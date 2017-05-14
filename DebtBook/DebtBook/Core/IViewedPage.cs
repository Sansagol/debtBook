using System;
using System.Collections.Generic;
using System.Text;

namespace DebtBook.Core
{
    interface IViewedPage
    {
        ViewModelBase VM { get; set; }
    }
}
