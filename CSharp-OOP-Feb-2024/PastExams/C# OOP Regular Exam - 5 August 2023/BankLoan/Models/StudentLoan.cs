using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class StudentLoan : Loan
    {
        public StudentLoan() : base(1, 10000)
        {
        }
    }
}
