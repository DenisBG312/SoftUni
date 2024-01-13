namespace _07._Company_Users
{

    class Company
    {
        public string CompanyName { get; set; }
        public List<string> EmployeeID { get; set; }

        public Company(string companyName)
        {
            CompanyName = companyName;
            EmployeeID = new List<string>();
        }

        public override string ToString()
        {
            string result = $"{CompanyName}\n";

            for (int i = 0; i < EmployeeID.Count; i++)
            {
                result += $"--{EmployeeID[i]}\n";
            }
            return result.Trim();
        }
    }
    internal class Program
    {

        static void Main(string[] args)
        {
            Dictionary<string, Company> companyMap = new Dictionary<string, Company>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split("->");
                string companyName = arguments[0];
                string employeeId = arguments[1];
                if (!companyMap.ContainsKey(companyName))
                {
                    Company company = new Company(companyName);
                    companyMap.Add(companyName, company);
                }

                if (!companyMap[companyName].EmployeeID.Contains(employeeId))
                {
                    companyMap[companyName].EmployeeID.Add(employeeId);
                }
            }

            foreach (KeyValuePair<string, Company> company in companyMap)
            {
                Console.WriteLine(company.Value.ToString());
            }
        }
    }
}
