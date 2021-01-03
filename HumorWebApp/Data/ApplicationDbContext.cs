using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using HumorWebApp.Models;

namespace HumorWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<HumorWebApp.Models.EvaluationItem> EvaluationItem { get; set; }
        public DbSet<HumorWebApp.Models.UserAnswer> UserAnswer { get; set; }
        public DbSet<HumorWebApp.Models.Match> Match { get; set; }
        
    }
}
