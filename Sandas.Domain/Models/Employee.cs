using Sandas.Domain.Models.Abstract;
using System;
using System.Collections.Generic;

namespace Sandas.Domain.Models
{
    public class Employee : Person
    {
        public string CompensationType { get; set; }
        public int Amount { get; set; }

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
    }
}
