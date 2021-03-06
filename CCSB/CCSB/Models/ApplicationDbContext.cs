using CCSB.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CCSB.Models.ViewModels;


namespace CCSB.Models
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Appointment> Appointments { get; set; }
		public DbSet<Customer> Customer { get; set; }
		public DbSet<Vehicles> Vehicles { get; set; }
		public DbSet<Contract> Contracts { get; set; }
	}

}
