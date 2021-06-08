using Sandas.Domain.Models;
using System.Collections.Generic;

namespace ConsoleApp.Sandas.Services.Interfaces
{
    public interface IFileService
    {
        List<Employee> ReturnByEmployeeAndCompensationType();
        List<Employee> ReturnTotalAmounts();
        void WriteEmployeeAndCompensationToCsvFile();
        void WriteTotalAmountsToCsvFile();
    }
}
