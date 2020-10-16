using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public interface IReportingStructureService
    {
        /// <summary>
        /// Function to get the reporting structure of an employee based on employee id
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <returns>Reporting structure of the employee</returns>
        ReportingStructure GetReportingStructureById(String id);     
    }
}
