﻿using Identity.AuthServer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.AuthServer.Infrastructure
{
    public class BFIdentityContext : IdentityDbContext<UserEntity, UserRoleEntity, Guid>
    {
        public BFIdentityContext(Microsoft.EntityFrameworkCore.DbContextOptions options) : base(options) { }
    }
}
