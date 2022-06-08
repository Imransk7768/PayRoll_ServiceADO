using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpServiceADO
{
    public class EmpModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public DateTime StartDate { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public decimal Deductions { get; set; }
        public decimal Taxable_Pay { get; set; }
        public decimal Income_Tax { get; set; }
        public decimal Net_Pay { get; set; }
    }
}
