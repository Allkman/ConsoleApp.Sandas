﻿using Sandas.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Sandas.Services.Interfaces
{
    public interface IFileService
    {
        List<Employee> ReturnTotalAmounts();
    }
}
