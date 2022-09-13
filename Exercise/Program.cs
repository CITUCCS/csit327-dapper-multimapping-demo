
using DapperDemo.Models;
using DapperDemo.Repositories;

internal class Program
{
    private static void Main(string[] args)
    {
        IAgentRepository agentRepository = new AgentRepository();
        IRoleRepository roleRepository = new RoleRepository();

        //var newAgent = new Agent
        //{
        //    Name = "Fade",
        //    Country = "Turkey",
        //    Role = new Role
        //    {
        //        Id = 3
        //    }
        //};

        //agentRepository.Add(newAgent);

        // print all
        foreach (var agent in agentRepository.GetAll())
        {
            /**
            {
                "Id": 1,
                "Name": "Jett",
                "Country": "Korea",
                "Role": 
                {
                    "Id": 1
                    "Name": "Duelist"
                    "Description": "Description ni role"
                }
            }
            **/
            Console.WriteLine(agent);
        }

        foreach (var role in roleRepository.GetAll())
        {
            /**
            {
                "Id": 1
                "Name": "Duelist"
                "Description": "Description ni role"
                "Agents" : 
                    [
                        {
                            "Id": 1,
                            "Name": "Jett",
                            "Country": "Korea"
                        }
                    ]
            }
            **/
            Console.WriteLine(role);
        }
    }
}