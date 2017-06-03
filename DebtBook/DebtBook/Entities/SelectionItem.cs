using System;
using System.Collections.Generic;
using System.Text;

namespace DebtBook.Entities
{
    class SelectionItem
    {
        public object SourceObject { get; set; }
        public string Title { get; set; }
        public Action CommandHandler { get; set; }
    }
}
