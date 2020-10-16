using challenge.Data;
using challenge.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public class CompensationRepository : ICompensationRepository
    {
        private readonly EmployeeContext _employeeContext;
        private readonly ILogger<ICompensationRepository> _logger;

        /// <summary>
        /// Constructor for CompensationRepository
        /// </summary>
        /// <param name="logger">Logger object for CompensationRepository using DI</param>
        /// <param name="employeeContext">DBContext object introduced using DI</param>
        public CompensationRepository(ILogger<ICompensationRepository> logger, EmployeeContext employeeContext)
        {
            _employeeContext = employeeContext;
            _logger = logger;
        }

        /// <summary>
        /// Function to add new Compensation object
        /// </summary>
        /// <param name="compensation">The Compensation object which is to be added</param>
        /// <returns>The Compensation which is added</returns>
        public Compensation Add(Compensation compensation)
        {
            _employeeContext.Compensations.Update(compensation);
            return compensation;
        }

        /// <summary>
        /// Function to get the compensation by employee Id
        /// </summary>
        /// <param name="id">Id of employee whose compensation is requested</param>
        /// <returns>Compensation of the employee</returns>
        public Compensation GetByEmployeeId(string id)
        { 
            return _employeeContext.Compensations.Include(e => e.Employee).SingleOrDefault(e => e.Employee.EmployeeId == id);
        }

        /// <summary>
        /// Function to save any changes made in the context
        /// </summary>
        /// <returns></returns>
        public Task SaveAsync()
        {
            return _employeeContext.SaveChangesAsync();
        }
      
    }
}
