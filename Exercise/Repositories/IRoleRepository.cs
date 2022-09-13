﻿using DapperDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDemo.Repositories
{
    internal interface IRoleRepository
    {
        IEnumerable<Role> GetAll();
    }
}
