using Sandas.Domain.Models;
using System.Collections.Generic;

namespace ConsoleApp.Sandas.Services.Interfaces
{
    public interface IFileService
    {
        List<Employee> ReadCsvFile();
        void ReturnTotalAmounts();
    }
}
