using challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace challenge.Services
{
    public interface ICompensationService
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
        Compensation Create(Compensation employee);

    }
}
