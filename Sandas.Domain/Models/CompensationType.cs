using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandas.Domain.Models
{
    public class CompensationType : Employee
    {
        public int CompensationTypeId { get; set; }
        public int Salary { get; set; }
        public int Bonus { get; set; }
        public int Premium { get; set; }
        public int Vacation { get; set; }
        public int Amount { get; set; }
        public int TotalAmount { get; set; }
        public double Taxes { get; set; }
    }
}
