using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    internal class Agent
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Country { get; set; }
        public Role? Role { get; set; }

        // Returns a JSON string representation of this instance
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
