using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using challenge.Models;
using Microsoft.Extensions.Logging;
using challenge.Repositories;

namespace challenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        /// <summary>
        /// Constructor for CompensationService
        /// </summary>
        /// <param name="logger">Logger object for CompensationService using DI</param>
        /// <param name="employeeService">IEmployeeService object introduced using DI</param>
        /// <param name="compensationRepository">ICompensationRepository object introduced using DI</param>
        public CompensationService(ILogger<CompensationService> logger, 
            IEmployeeService employeeService, 
            ICompensationRepository compensationRepository)
        {
            _employeeService = employeeService;
            _logger = logger;
            _compensationRepository = compensationRepository;
        }

        /// <summary>
        /// Function to add new Compensation object
        /// </summary>
        /// <param name="compensation">The Compensation object which is to be added</param>
        /// <returns>The Compensation which is added</returns>
        public Compensation Create(Compensation compensation)
        {
            if (compensation != null)
            {
                _compensationRepository.Add(compensation);
                _compensationRepository.SaveAsync().Wait();
            }

            return compensation;
        }

        /// <summary>
        /// Function to get the compensation by employee Id
        /// </summary>
        /// <param name="id">Id of employee whose compensation is requested</param>
        /// <returns>Compensation of the employee</returns>
        public Compensation GetByEmployeeId(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetByEmployeeId(id);
            }

            return null;
        }
    }
}
