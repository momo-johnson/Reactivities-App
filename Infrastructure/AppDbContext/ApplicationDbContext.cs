using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppDbContext
{
	public class ApplicationDbContext : DbContext
	{


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

            
        }

        public DbSet<Activity> Activities { get; set; }
    }
}

