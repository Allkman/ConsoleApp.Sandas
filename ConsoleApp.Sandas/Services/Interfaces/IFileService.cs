using Sandas.Domain.Models;
using System.Collections.Generic;

namespace ConsoleApp.Sandas.Services.Interfaces
{
    interface IFileService
    {
        void WriteTotalAmountsAndTaxesToCsvFile();
        void WriteEmployeeAndCompensationTypeToCsvFile();

    }
}
