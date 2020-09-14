﻿using Microsoft.EntityFrameworkCore;
using MockSchoolManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MockSchoolManagement.Ef
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        { 
        }

        public DbSet<Student> Students { get; set; }
    }
}
