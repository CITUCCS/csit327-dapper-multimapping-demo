using Dapper;
using DapperDemo.Context;
using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Repositories
{
    internal class RoleRepository : IRoleRepository
    {
        private DapperContext _context;

        public RoleRepository()
        {
            _context = new DapperContext("Data Source=JCA-PC;Initial Catalog=ValoDb2;Integrated Security=True;Connect Timeout=60;Encrypt=False;TrustServerCertificate=False;");
        }
        public IEnumerable<Role> GetAll()
        {
            var sql = "SELECT * FROM Role r INNER JOIN Agent a ON r.Id = a.RoleId;";
            using (var connection = _context.CreateConnection())
            {
                var roles = connection.Query<Role, Agent, Role>(sql, (role, agent) =>
                {
                    role.Agents.Add(agent);
                    return role;
                });
                // Group By Linq
                return roles.GroupBy(r => r.Id).Select(g =>
                {
                    var firstRoleInGroup = g.First();
                    firstRoleInGroup.Agents = g.SelectMany(role => role.Agents).ToList();

                    return firstRoleInGroup;
                });
            }
        }
    }
}
