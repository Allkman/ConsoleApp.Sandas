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
            fileService.WriteToCsvFile();
            Console.WriteLine();
            Console.WriteLine("---= PRESS ANY KEY =---");
            Console.ReadKey();
        }
    }
}
