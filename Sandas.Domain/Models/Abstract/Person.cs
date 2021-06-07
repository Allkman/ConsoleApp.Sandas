using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandas.Domain.Models.Abstract
{
    public abstract class Person
    {
        public int PersonId { get; set; }
        [Name("FullName")]
        public string FullName { get; set; }
    }
}
