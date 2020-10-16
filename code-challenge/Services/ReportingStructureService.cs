using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class ReportingStructureService : IReportingStructureService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ILogger<ReportingStructureService> _logger;

        /// <summary>
        /// Constructor for ReportingStructureService
        /// </summary>
        /// <param name="logger">Logger object for ReportingStructureService using DI</param>
        /// <param name="employeeService">IEmployeeService object introduced using DI</param>
        public ReportingStructureService(ILogger<ReportingStructureService> logger, IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _logger = logger;
        }


        /// <summary>
        /// Function to get the reporting structure of an employee based on employee id
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <returns>Reporting structure of the employee</returns>
        public ReportingStructure GetReportingStructureById(String id)
        {
            if (String.IsNullOrEmpty(id))
            {
                return null;
            }
            Employee employee = _employeeService.GetById(id);
            if(employee == null)
            {
                return null;
            }
            ReportingStructure reportingStructure = new ReportingStructure()
            {
                Employee = employee,
                NumberOfDirectReports = GetDirectReportCountByEmployee(id)
            };
            return reportingStructure;
        }

        /// <summary>
        /// This is a function that perform a depth first search on the employee direct reports hirerarchy and
        /// calculates the number of direct reports for an employee using employee id.
        /// </summary>
        /// <param name="id">Id of the employee</param>
        /// <returns>Number of direct reports for the employee</returns>
        private int GetDirectReportCountByEmployee(String id)
        {
            int directReportCount = 0;
            Employee employee = _employeeService.GetById(id);
            if (employee.DirectReports == null)
            {
                return directReportCount;
            }
            foreach (Employee emp in employee.DirectReports)
            {
                // recursive call until the employee with no direct reports is reached
                directReportCount += GetDirectReportCountByEmployee(emp.EmployeeId) + 1;
            }
            return directReportCount;
        }
    }
}
