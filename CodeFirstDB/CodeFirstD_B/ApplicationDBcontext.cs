using System;

public class ApplicationDBcontext: Dbcontext
{
	public ApplicationDBcontext(DbContextOptions<ApplicationDBcontext> options): base(options)
	{
	}
	public Dbset<Item> Items { get; set; }
}
