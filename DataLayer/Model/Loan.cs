using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Model
{
    public class Loan
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public DateTime LoanDate { get; set; }
        public double loanBalance { get; set; }
        public double UsedAmount { get; set; }
        public string InstallmentPlan { get; set; }



    }
}
