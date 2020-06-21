using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server.Сущности
{
	public class Сущность0
	{
		public Guid Id { get; set; }

		public bool Параметр0 { get; set; }

		public DateTime? Параметр1 { get; set; }
	}

	public class КонфигурацияСущности0 : IEntityTypeConfiguration<Сущность0>
	{
		public void Configure(EntityTypeBuilder<Сущность0> builder)
		{
			builder.Property(p => p.Параметр1).HasColumnType("DATETIME2(0)");
		}
	}
}
