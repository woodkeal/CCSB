using CCSB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace CCSB.Models
{
	public class ApplicationDBcontext : IdentityDbContext
	{
		public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options) : base(options)
		{

		}

        public DbSet<Appointments> Appointments { get; set; }
		public DbSet<CustomerDetails> CustomerDetails { get; set; }
		public DbSet<Vehicles> Vehicles { get; set; }

	}

}
