using ConsoleApp.Sandas.Services;
using CsvHelper;
using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using Sandas.Domain.Models;
using ConsoleApp.Sandas.Services.Interfaces;

namespace ConsoleApp.Sandas
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileService fileService = new FileService();
            //fileService.PrintAllCsv(); //for testing

            fileService.ReturnTotalAmounts();

            Console.WriteLine();
            Console.WriteLine("---= PRESS ANY KEY =---");
            Console.ReadKey();
        }
    }
}
