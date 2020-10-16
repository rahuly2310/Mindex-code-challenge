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
    [Route("api/reportingstructure")]
    public class ReportingStructureController : Controller
    {
        private readonly ILogger _logger;
        private readonly IReportingStructureService _reportingStructureService;

        /// <summary>
        /// Constructor for ReportingStructureController
        /// </summary>
        /// <param name="logger">Logger object for ReportingStructureController using DI</param>
        /// <param name="reportingStructureService">IReportingStructureService object introduced using DI</param>
        public ReportingStructureController(ILogger<ReportingStructureController> logger, IReportingStructureService reportingStructureService)
        {
            _logger = logger;
            _reportingStructureService = reportingStructureService;
        }
      

        [HttpGet("{id}", Name = "getReportingStructureById")]
        /// <summary>
        /// Function to get the reporting structure of an employee based on employee id
        /// </summary>
        /// <param name="id">The id of the employee</param>
        /// <returns>Reporting structure of the employee</returns>
        public IActionResult GetReportingStructureById(String id)
        {
            try
            {
                _logger.LogDebug($"Received employee get reporting structure request for '{id}'");

                var reportingStructure = _reportingStructureService.GetReportingStructureById(id);

                if (reportingStructure == null)
                    return NotFound();

                return Ok(reportingStructure);
            }
            catch(Exception ex)
            {
                return Json($"EXCEPTION: Get Reporting Structure By Id : {id}, Exception Message: {ex.Message}");
            }
        }
       
    }
}
