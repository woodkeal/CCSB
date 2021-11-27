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


        public virtual DbSet<Appointment> Appointments { get; set; }
		public virtual DbSet<Customer> Customer { get; set; }
		public virtual DbSet<Vehicles> Vehicles { get; set; }
        public virtual DbSet<Contract> Contracts { get;  set; }
		public virtual DbSet<Camper> Campers { get; set; }
		public virtual DbSet<Caravan> Caravans { get; set; }
	}

}
