using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Core.Contracts;
using BankLoan.Models;
using BankLoan.Models.Contracts;
using BankLoan.Repositories;
using BankLoan.Repositories.Contracts;
using BankLoan.Utilities.Messages;
using ArgumentException = System.ArgumentException;

namespace BankLoan.Core
{
    public class Controller : IController
    {
        private IRepository<ILoan> loans;
        private IRepository<IBank> banks;
        private string[] bankTypes = new string[] { nameof(BranchBank), nameof(CentralBank) };
        private string[] loanTypes = new string[] { nameof(StudentLoan), nameof(MortgageLoan) };
        private string[] clientTypes = new string[] { nameof(Adult), nameof(Student) };

        public Controller()
        {
            loans = new LoanRepository();
            banks = new BankRepository();
        }

        public string AddBank(string bankTypeName, string name)
        {
            if (!bankTypes.Contains(bankTypeName))
            {
                throw new ArgumentException(ExceptionMessages.BankTypeInvalid);
            }

            IBank bank = null;
            if (bankTypeName == nameof(BranchBank))
            {
                bank = new BranchBank(name);
            }
            else if (bankTypeName == nameof(CentralBank))
            {
                bank = new CentralBank(name);
            }

            banks.AddModel(bank);
            return $"{string.Format(OutputMessages.BankSuccessfullyAdded, bankTypeName)}";
        }

        public string AddLoan(string loanTypeName)
        {
            if (!loanTypes.Contains(loanTypeName))
            {
                throw new ArgumentException(ExceptionMessages.LoanTypeInvalid);
            }

            ILoan loan = null;
            if (loanTypeName == nameof(StudentLoan))
            {
                loan = new StudentLoan();
            }
            else if (loanTypeName == nameof(MortgageLoan))
            {
                loan = new MortgageLoan();
            }

            loans.AddModel(loan);
            return $"{string.Format(OutputMessages.LoanSuccessfullyAdded, loanTypeName)}";

        }

        public string ReturnLoan(string bankName, string loanTypeName)
        {
            var loan = loans.FirstModel(loanTypeName);

            if (loan is null)
            {
                string message = string.Format(ExceptionMessages.MissingLoanFromType, loanTypeName);
                throw new ArgumentException(message);
            }

            var bank = banks.FirstModel(bankName);
            bank.AddLoan(loan);
            loans.RemoveModel(loan);

            return string.Format(OutputMessages.LoanReturnedSuccessfully, loanTypeName, bankName);
        }

        public string AddClient(string bankName, string clientTypeName, string clientName, string id, double income)
        {
            if (!clientTypes.Contains(clientTypeName))
            {
                throw new ArgumentException(ExceptionMessages.ClientTypeInvalid);
            }

            IBank bank = banks.FirstModel(bankName);

            if (clientTypeName == nameof(Student) && bank.GetType().Name == "CentralBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }

            if (clientTypeName == nameof(Adult) && bank.GetType().Name == "BranchBank")
            {
                return string.Format(OutputMessages.UnsuitableBank);
            }

            IClient client = null;
            if (clientTypeName == nameof(Student))
            {
                client = new Student(clientName, id, income);
            }
            else if (clientTypeName == nameof(Adult))
            {
                client = new Adult(clientName, id, income);
            }

            bank.AddClient(client);
            return $"{string.Format(OutputMessages.ClientAddedSuccessfully, clientTypeName, bankName)}";
        }

        public string FinalCalculation(string bankName)
        {
            IBank bank = banks.FirstModel(bankName);
            double bankIncome = bank.Clients.Select(x => x.Income).Sum();
            double bankLoan = bank.Loans.Sum(x => x.Amount);

            return $"{string.Format(OutputMessages.BankFundsCalculated, bankName, $"{bankIncome + bankLoan:F2}")}";
        }

        public string Statistics()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var bank in banks.Models)
            {
                sb.AppendLine(bank.GetStatistics());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
