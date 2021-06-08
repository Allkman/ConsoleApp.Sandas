using Sandas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ConsoleApp.Sandas.Services.Interfaces;
using System.Text;
using System.Reflection;

namespace ConsoleApp.Sandas.Services
{
    //internal class only for ConsoleApp.Sandas project
    class FileService : IFileService
    {
        readonly string filePath = $"C:{Path.DirectorySeparatorChar}SandasTemp{Path.DirectorySeparatorChar}duomenys.csv";
        string newFilePath = $"C:{Path.DirectorySeparatorChar}SandasTemp{Path.DirectorySeparatorChar}newdata.csv";

        public List<Employee> ReadCsvFile()
        {
            return File.ReadAllLines(filePath)
                .Skip(1) // skipping 1st (Column Headers) row
                .Where(row => row.Length > 0)
                .Select(Employee.ParseRow).ToList();
        }
        private void PrintAllCsv() //this method is only for testing...
        {
            var allEmployees = ReadCsvFile();
            foreach (var employee in allEmployees)
            {
                Console.WriteLine($"{employee.FullName};{employee.CompensationType};{employee.Amount}");
            }
        }
        public List<Employee> ReturnTotalAmounts()
        {
            var employeesList = ReadCsvFile();
            var groupAmounts =
                 from employee in employeesList
                 group employee by employee.FullName into employeeGroup
                 select new Employee
                 {
                     FullName = employeeGroup.Key,
                     TotalAmount = employeeGroup.Sum(x => x.Amount),
                     Taxes = (employeeGroup.Sum(x => x.Amount) * 1.4) - employeeGroup.Sum(x => x.Amount),
                 };
            foreach (var amount in groupAmounts)
            {
                Console.WriteLine($"{amount.FullName};{amount.TotalAmount};{amount.Taxes}");
            }
            return groupAmounts.ToList();
        }        
        public void WriteToCsvFile()
        {
            var csvText = ReturnTotalAmounts();
            var sb = new StringBuilder();
            sb.AppendLine("FullName;TotalAmount;Taxes");
            foreach (var item in csvText)
            {
                sb.AppendLine(item.ToString());
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText(newFilePath, sb.ToString());
        }
    }
}