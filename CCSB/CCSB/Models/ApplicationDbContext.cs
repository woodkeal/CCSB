using CCSB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CCSB.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

        public DbSet<Appointments> Appointments { get; set; }
		public DbSet<CustomerDetails> CustomerDetails { get; set; }
		public DbSet<Vehicles> Vehicles { get; set; }

	}

}
