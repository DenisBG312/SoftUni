using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;

namespace BankLoan.Models
{
    public abstract class Loan : ILoan
    {
        public Loan(int interestRate, double amount)
        {
            InterestRate = interestRate;
            Amount = amount;
        }
        public int InterestRate { get; private set; }
        public double Amount { get; private set; }
    }
}
