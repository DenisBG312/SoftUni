using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoan.Models
{
    public class BranchBank : Bank
    {
        public BranchBank(string name) : base(name, 25)
        {
        }
    }
}
