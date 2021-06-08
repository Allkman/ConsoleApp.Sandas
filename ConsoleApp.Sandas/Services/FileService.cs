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
        string totalAmountsFilePath = $"C:{Path.DirectorySeparatorChar}SandasTemp{Path.DirectorySeparatorChar}totalAmounts.csv";
        string employeeAndCompensationTypeFilePath = $"C:{Path.DirectorySeparatorChar}SandasTemp{Path.DirectorySeparatorChar}employeeAndCompensationType.csv";

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
            return groupAmounts.ToList();
        }
        public void WriteTotalAmountsToCsvFile()
        {
            var csvText = ReturnTotalAmounts();
            var sb = new StringBuilder();
            sb.AppendLine("FullName;TotalAmount;Taxes");
            foreach (var item in csvText)
            {
                sb.AppendLine(item.ToString());
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText(totalAmountsFilePath, sb.ToString());
        }
        //--2nd part of an assignment
        public List<Employee> ReturnByEmployeeAndCompensationType()
        {
            var employeesList = ReadCsvFile();
            var groupByEmployeeAndCompensationType =
                employeesList.GroupBy(x => new { x.FullName, x.CompensationType })
                .Select(e => new Employee
                {
                    FullName = e.Key.FullName,
                    CompensationType = e.Key.CompensationType,
                    TotalAmount = e.Sum(a => a.Amount),
                });
            foreach (var item in groupByEmployeeAndCompensationType)
            {
                Console.WriteLine($"{item.FullName};{item.CompensationType},{item.TotalAmount}");
            }
            return groupByEmployeeAndCompensationType.ToList();
        }
        public void WriteEmployeeAndCompensationToCsvFile()
        {
            var csvText = ReturnByEmployeeAndCompensationType();
            var sb = new StringBuilder();
            sb.AppendLine("FullName;CompensationType;TotalAmount");
            foreach (var item in csvText)
            {
                sb.AppendLine(item.ToString());
            }
            Console.WriteLine(sb.ToString());
            File.WriteAllText(employeeAndCompensationTypeFilePath, sb.ToString());
        }
    }
}