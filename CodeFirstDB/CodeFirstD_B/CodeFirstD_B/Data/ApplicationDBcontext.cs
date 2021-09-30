using System.Data.Entity;
using CodeFirstD_B.Models;
using Microsoft.EntityFrameworkCore;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

public class ApplicationDBcontext: DbContext
{
	public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options): base(options)
	{
	}
	public System.Data.Entity.DbSet<Item> Items { get; set; }
}
