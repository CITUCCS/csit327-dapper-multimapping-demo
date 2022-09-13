using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Repositories
{
    internal interface IAgentRepository
    {
        /// <summary>
        /// Gets all Agents
        /// </summary>
        /// <returns>An enumerable of Agents</returns>
        IEnumerable<Agent> GetAll();

        /// <summary>
        /// Insert an agent
        /// </summary>
        /// <param name="agent"></param>
        /// <returns>Id of the newly inserted agent</returns>
        int Add(Agent agent);
    }
}
