using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class CentralBank : Bank
    {
        public CentralBank(string name) : base(name, 50)
        {
        }
    }
}
