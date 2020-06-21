using Microsoft.EntityFrameworkCore;
using Server.Сущности;

namespace Server.Данные
{
	public class DatabaseContext : DbContext
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=localhost;Database=virginefcore;Trusted_Connection=True;MultipleActiveResultSets=True;Connection Timeout=30;");
		}



		public DbSet<Сущность0> Сущности0 { get; set; }




		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.ApplyConfiguration(new КонфигурацияСущности0());
		}
	}
}
