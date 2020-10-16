using challenge.Models;
using System;
using System.Threading.Tasks;

namespace challenge.Repositories
{
    public interface ICompensationRepository
    {
        /// <summary>
        /// Function to get the compensation by employee Id
        /// </summary>
        /// <param name="id">Id of employee whose compensation is requested</param>
        /// <returns>Compensation of the employee</returns>
        Compensation GetByEmployeeId(String id);

        /// <summary>
        /// Function to add new Compensation object
        /// </summary>
        /// <param name="compensation">The Compensation object which is to be added</param>
        /// <returns>The Compensation which is added</returns>
        Compensation Add(Compensation compensation);

        /// <summary>
        /// Function to save any changes made in the context
        /// </summary>
        /// <returns></returns>
        Task SaveAsync();
    }
}