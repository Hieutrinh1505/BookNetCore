using System;
using BookNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookNetCore.Data
{
	public class ApplicationDbContext: DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Category> Categories { get; set; }

	}
	
}

