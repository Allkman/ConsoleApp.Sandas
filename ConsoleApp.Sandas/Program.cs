using ConsoleApp.Sandas.Services;
using System;
using ConsoleApp.Sandas.Services.Interfaces;

namespace ConsoleApp.Sandas
{
    class Program
    {
        static void Main(string[] args)
        {
            IFileService fileService = new FileService();
            //fileService.PrintAllCsv(); //for testing
            Console.WriteLine("||--------1st PART--------||");
            Console.WriteLine();           
            Console.WriteLine("|--------------------WriteTotalAmountsAndTaxesToCsvFile();--------------------|");
            fileService.WriteTotalAmountsAndTaxesToCsvFile();
            Console.WriteLine();
            Console.WriteLine("||--------2st PART--------||");            
            Console.WriteLine();
            Console.WriteLine("|--------------------WriteEmployeeAndCompensationToCsvFile();--------------------|");
            fileService.WriteEmployeeAndCompensationTypeToCsvFile();
            Console.WriteLine();
            Console.WriteLine("---= PRESS ANY KEY =---");
            Console.ReadKey();
        }
    }
}
