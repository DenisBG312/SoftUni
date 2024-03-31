using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankLoan.Models.Contracts;
using BankLoan.Utilities.Messages;

namespace BankLoan.Models
{
    public abstract class Bank : IBank
    {
        private string name;
        private List<ILoan> loans;
        private List<IClient> clients;

        public Bank(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            loans = new List<ILoan>();
            clients = new List<IClient>();
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.BankNameNullOrWhiteSpace);
                }
                name = value;
            }

        }
        public int Capacity { get; private set; }
        public IReadOnlyCollection<ILoan> Loans => loans.AsReadOnly();

        public IReadOnlyCollection<IClient> Clients => clients.AsReadOnly();
        public double SumRates()
        {
            return loans.Sum(l => l.InterestRate);
        }

        public void AddClient(IClient client)
        {
            if (this.Clients.Count < this.Capacity)
            {
                this.clients.Add(client);
            }
            else
            {
                throw new ArgumentException(ExceptionMessages.NotEnoughCapacity);
            }
        }

        public void RemoveClient(IClient client)
        {
            clients.Remove(client);
        }

        public void AddLoan(ILoan loan)
        {
            loans.Add(loan);
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Name: {name}, Type: {this.GetType().Name}");
            if (clients.Count == 0)
            {
                sb.AppendLine("Clients: none");
            }
            else
            {
                string[] names = clients.Select(n => n.Name).ToArray();
                sb.AppendLine($"Clients: {string.Join(", ", names)}");
            }

            sb.AppendLine($"Loans: {loans.Count}, Sum of Rates: {loans.Sum(x => x.InterestRate)}");
            return sb.ToString().TrimEnd();
        }
    }
}
