﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyName { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public bool? IsOwner { get; set; } = false;

    }
}

