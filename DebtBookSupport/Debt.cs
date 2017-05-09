using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DebtBookSupport
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

        public Debt()
        {
            DateBegin = DateTime.Now;
        }
    }
}
