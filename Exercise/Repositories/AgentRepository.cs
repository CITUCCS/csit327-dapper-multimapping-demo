using Dapper;
using DapperDemo.Context;
using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Repositories
{
    internal class AgentRepository : IAgentRepository
    {
        private readonly DapperContext _context;

        public AgentRepository()
        {
            // replace with your db server connection string
            _context = new DapperContext("Data Source=JCA-PC;Initial Catalog=ValoDb2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;");
        }

        public int Add(Agent agent)
        {
            var sql = "INSERT INTO AGENT (Name, Country, RoleId) VALUES (@Name, @Country, @RoleId);" +
                "SELECT CAST(SCOPE_IDENTITY() as int);";

            using (var connection = _context.CreateConnection())
            {
                return connection.ExecuteScalar<int>(sql, new { agent.Name, agent.Country, RoleId = agent.Role.Id});
            }
        }

        public IEnumerable<Agent> GetAll()
        {
            var sql = "SELECT * FROM Agent a INNER JOIN Role r ON a.RoleId = r.Id;";

            using (var connection = _context.CreateConnection())
            {
                // Query<Obj1, Obj2,....., ReturnObject>
                return connection.Query<Agent, Role, Agent>(sql, (agent, role) => 
                {
                    agent.Role = role;
                    return agent;
                });
                //  Agent <-------- Id=---------> Role
                // SplitOn default value is Id
            }
        }
    }
}
