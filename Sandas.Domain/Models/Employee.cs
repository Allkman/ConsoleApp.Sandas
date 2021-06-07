using CsvHelper.Configuration.Attributes;
using Sandas.Domain.Models.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandas.Domain.Models
{
    public class Employee : Person
    {
        public int EmployeeId { get; set; }
        public CompensationType CompensationType { get; set; }
    }
}
