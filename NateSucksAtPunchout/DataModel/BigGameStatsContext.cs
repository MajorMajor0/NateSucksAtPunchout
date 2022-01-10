using Microsoft.EntityFrameworkCore;

namespace NateSucksAtPunchout.DataModel
{
	public partial class BigGameStatsContext : DbContext
	{
		public BigGameStatsContext()
		{
		}

		public BigGameStatsContext(DbContextOptions<BigGameStatsContext> options)
			: base(options)
		{
		}

		public virtual DbSet<BigGame> BigGames { get; set; }
		public virtual DbSet<Finish> Finishes { get; set; }
		public virtual DbSet<Kill> Kills { get; set; }
		public virtual DbSet<Location> Locations { get; set; }
		public virtual DbSet<Player> Players { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
				optionsBuilder.UseSqlite(ConnectionStrings.BigGameStatsDb);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<BigGame>(entity =>
			{
				entity.HasKey(e => e.Year);

				entity.ToTable("BigGame");

				entity.HasIndex(e => e.Date)
					.IsUnique();

				entity.HasIndex(e => e.Year)
					.IsUnique();

				entity.Property(e => e.Year).ValueGeneratedNever();

				entity.Property(e => e.BuyIn).HasColumnType("DOUBLE");

				entity.Property(e => e.Date)
					.IsRequired()
					.HasColumnType("DATE");

				entity.Property(e => e.Length).HasColumnType("DOUBLE");

				entity.Property(e => e.LocationId).HasColumnName("Location_ID");

				entity.HasOne(d => d.Location)
					.WithMany(p => p.BigGames)
					.HasForeignKey(d => d.LocationId)
					.OnDelete(DeleteBehavior.SetNull);
			});

			modelBuilder.Entity<Finish>(entity =>
			{
				entity.HasKey(e => new { e.Year, e.Player });

				entity.ToTable("Finish");

				entity.Property(e => e.Amount).HasColumnType("DOUBLE");

				entity.Property(e => e.Time).HasColumnType("DOUBLE");

				entity.HasOne(d => d.PlayerNavigation)
					.WithMany(p => p.Finishes)
					.HasForeignKey(d => d.Player)
					.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(d => d.YearNavigation)
					.WithMany(p => p.Finishes)
					.HasForeignKey(d => d.Year)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<Kill>(entity =>
			{
				entity.HasKey(e => new { e.BigGame, e.Killed });

				entity.ToTable("Kill");

				entity.Property(e => e.Killer).IsRequired();

				entity.HasOne(d => d.BigGameNavigation)
					.WithMany(p => p.Kills)
					.HasForeignKey(d => d.BigGame)
					.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(d => d.KilledNavigation)
					.WithMany(p => p.KillKilledNavigations)
					.HasForeignKey(d => d.Killed)
					.OnDelete(DeleteBehavior.ClientSetNull);

				entity.HasOne(d => d.KillerNavigation)
					.WithMany(p => p.KillKillerNavigations)
					.HasForeignKey(d => d.Killer)
					.OnDelete(DeleteBehavior.ClientSetNull);
			});

			modelBuilder.Entity<Location>(entity =>
			{
				entity.ToTable("Location");

				entity.HasIndex(e => e.Id)
					.IsUnique();

				entity.Property(e => e.Id)
					.HasColumnName("ID")
					.ValueGeneratedNever();
			});

			modelBuilder.Entity<Player>(entity =>
			{
				entity.HasKey(e => e.FirstName);

				entity.ToTable("Player");
			});

			OnModelCreatingPartial(modelBuilder);
		}

		partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
	}
}
