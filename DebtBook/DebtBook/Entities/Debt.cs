using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBook.Entities
{
    /// <summary>
    /// Class describe a single debt entity.
    /// </summary>
    public class Debt
    {
        public string Id { get; set; }

        public double Value { get; set; }

        public double Rate { get; set; }

        public DateTime DateBegin { get; set; }

        public Debtor CurrentDebtor { get; set; }

        public string Details { get { return this.ToString(); } }

        public Debt()
        {
            DateBegin = DateTime.Now;
        }

        public override string ToString()
        {
            return string.Format($"{Value} * {Rate}%");
        }
    }
}
