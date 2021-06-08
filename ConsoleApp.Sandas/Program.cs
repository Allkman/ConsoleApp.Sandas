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

            fileService.ReturnTotalAmounts();
            Console.WriteLine("|--------------------Program.cs--------------------|");
            fileService.WriteTotalAmountsToCsvFile();
            Console.WriteLine("|--------------------Program.cs--------------------|");
            fileService.ReturnByEmployeeAndCompensationType();
            Console.WriteLine();
            //fileService.WriteEmployeeAndCompensationToCsvFile();
            Console.WriteLine("---= PRESS ANY KEY =---");
            Console.ReadKey();
        }
    }
}
