using Sandas.Domain.Models.Abstract;
using System;

namespace Sandas.Domain.Models
{
    public class Employee : Person
    {
        public string CompensationType { get; set; }
        public int Amount { get; set; }
        public int TotalAmount { get; set; }
        public double Taxes { get; set; }

        public static Employee ParseRow(string row)
        {
            var columns = row.Split(',');
            return new Employee()
            {
                FullName = columns[0],
                CompensationType = columns[1],
                Amount = Convert.ToInt32(columns[2])
            };
        }
        public override string ToString()
        {
            return this.FullName.ToString() + "," + this.TotalAmount + "," + this.Taxes.ToString();
        }
    }
}
