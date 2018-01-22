using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDWorkerApp
{
    public class Company
    {
        public int Id;
        public string FirstName;
        public string LastName;
        public decimal SalaryPerHour;

        public Company()
        {
        }
        public Company(int idWorker, string fName, string lName, decimal sPerHour)
        {
            Id = idWorker;
            FirstName = fName;
            LastName = lName;
            SalaryPerHour = sPerHour;
        }
        public int Calc (int a, int b)
        {
            int rez = a + b;
            return rez;
        }
    };
}
