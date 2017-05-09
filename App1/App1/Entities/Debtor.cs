using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook.Entities
{
    public class Debtor
    {
        public string Id { get; set; }

        public string Name { get; set; }

        /// <summary>Whet this debtor was added to DB.</summary>
        public DateTime DateAdded { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }
    }
}
