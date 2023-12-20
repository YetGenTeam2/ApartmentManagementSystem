﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentManagementSystem.Domain.Entities
{
    public class AppUser : IdentityUser
    {

        public string firstName { get; set; }
        public string lastName { get; set; }
        //public bool IsActive { get; set; }
        public List<Daire> daires { get; set; }

    }
}
