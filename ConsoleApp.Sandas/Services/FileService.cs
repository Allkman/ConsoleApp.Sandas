using Sandas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using ConsoleApp.Sandas.Services.Interfaces;

namespace ConsoleApp.Sandas.Services
{
    //internal class only for ConsoleApp.Sandas project
    public class FileService : IFileService
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
                Console.WriteLine($"{employee.FullName} \t {employee.CompensationType} \t {employee.Amount}");
            }
        }
        public void ReturnTotalAmounts()
        {
            var employeesList = ReadCsvFile();
            var groupAmounts =
                 from employee in employeesList
                 group employee by employee.FullName into employeeGroup
                 select new
                 {
                     FullName = employeeGroup.Key,
                     TotalAmount = employeeGroup.Sum(x => x.Amount),
                     Taxes = (employeeGroup.Sum(x => x.Amount) * 1.4) - employeeGroup.Sum(x => x.Amount),
                 };
            foreach (var amount in groupAmounts)
            {
                Console.WriteLine($"{amount.FullName} {amount.TotalAmount} {amount.Taxes}");
            }
        }
        //public List<Employee> WriteToCsvFile()
        //{

        //    return;
        //}        
    }
}