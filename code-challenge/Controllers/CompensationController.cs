using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using challenge.Services;
using challenge.Models;

namespace challenge.Controllers
{
    [Route("api/compensation")]
    public class CompensationController : Controller
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        /// <summary>
        /// Constructor for CompensationController
        /// </summary>
        /// <param name="logger">Logger object for CompensationController using DI</param>
        /// <param name="compensationService">ICompensationService object introduced using DI</param>
        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        
        [HttpPost]
        /// <summary>
        /// Function to add new Compensation object
        /// </summary>
        /// <param name="compensation">The Compensation object which is to be added</param>
        /// <returns>The Compensation which is added and object with created response</returns>
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            try
            {
                _logger.LogDebug($"Received employee create request for '{compensation.Employee.FirstName} " +
                    $"{compensation.Employee.LastName}'");

                _compensationService.Create(compensation);

                return CreatedAtRoute(new { id = compensation.Employee.EmployeeId }, compensation);
            }
            catch(Exception ex)
            {
                return Json($"EXCEPTION: Create Compensation : Exception Message: {ex.Message}");
            }
        }

        [HttpGet("{id}", Name = "getCompensationById")]
        /// <summary>
        /// Function to get the compensation of an employee based on id
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <returns>The Compensation of the employee</returns>
        public IActionResult GetCompensationById(String id)
        {
            try { 
                _logger.LogDebug($"Received compensation get request for '{id}'");

                var compensation = _compensationService.GetByEmployeeId(id);

                if (compensation == null)
                    return NotFound();

                return Ok(compensation);
            }
            catch (Exception ex)
            {
                return Json($"EXCEPTION: Get Compensation By Id :{id}, Exception Message: {ex.Message}");
            }
        }

    }
}
