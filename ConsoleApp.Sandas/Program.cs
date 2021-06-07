using ConsoleApp.Sandas.Services;
using CsvHelper;
using Sandas.Database;
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
            //db inicializavimui
            //var context = new ApplicationDbContext();
            //context.Database.EnsureCreated();

            IFileService fileService = new FileService();

            fileService.ReadCsvFile();
        }
    }
}
