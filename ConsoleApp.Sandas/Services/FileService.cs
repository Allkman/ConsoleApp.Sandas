using Sandas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using CsvHelper;
using System.Linq;
using System.Reflection;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ConsoleApp.Sandas.Services.Interfaces;

namespace ConsoleApp.Sandas.Services
{
    //internal class only for ConsoleApp.Sandas project
    public class FileService : IFileService
    {
        readonly string[] csvLines = File.ReadAllLines($"C:{Path.DirectorySeparatorChar}SandasTemp{Path.DirectorySeparatorChar}duomenys.csv");
        List<string> compensationTypes = new List<string>();
        public void ReadCsvFile()
        {
            //spliting each for into a column data.  i=1 because i m skipping header in line 0
            for (int i = 1; i < csvLines.Length; i++)
            {
                string[] rowData = csvLines[i].Split(',');
                compensationTypes.Add(rowData[1]);
            }
            for (int i = 0; i < compensationTypes.Count; i++)
            {
                Console.WriteLine(compensationTypes[i]);
            }
        }        
    }
}
