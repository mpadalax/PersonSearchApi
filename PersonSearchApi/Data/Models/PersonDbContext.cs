using Microsoft.EntityFrameworkCore;

namespace PersonSearchApi.Data.Models
{
  public class PersonDbContext : DbContext
  { 
    public PersonDbContext(DbContextOptions<PersonDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //modelBuilder.Entity<Person>().HasMany(p => p.Addresses).WithOne(a => a.Person).HasForeignKey(a => a.PersonId);

      modelBuilder.Entity<Interest>(entity =>
      {
        entity.Property(e => e.InterestId);

        entity.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(100);
      });
      modelBuilder.Entity<Address>(entity =>
      {
        entity.Property(e => e.AddressId);

        entity.Property(e => e.City)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Country)
            .IsRequired()
            .HasMaxLength(20);

        entity.Property(e => e.State)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Street1)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Street2).HasMaxLength(50);

        entity.Property(e => e.ZipCode)
            .IsRequired()
            .HasMaxLength(10);

        entity.HasOne(d => d.Person)
            .WithMany(p => p.Addresses)
            .HasForeignKey(d => d.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull);
      });
      modelBuilder.Entity<Person>(entity =>
      {
        entity.Property(e => e.PersonId);

        entity.Property(e => e.DateOfBirth).HasColumnType("date");

        entity.Property(e => e.Email)
            .IsRequired()
            .HasMaxLength(100);

        entity.Property(e => e.FirstName)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.LastName)
            .IsRequired()
            .HasMaxLength(50);

        entity.Property(e => e.Picture)
            .IsRequired()
            .HasMaxLength(255);
      });
      modelBuilder.Entity<PersonInterest>(entity =>
      {
        entity.HasKey(pi => new { pi.PersonId, pi.InterestId });

        entity.HasOne(d => d.Interest)
            .WithMany(i => i.PersonInterests)
            .HasForeignKey(d => d.InterestId)
            .OnDelete(DeleteBehavior.ClientSetNull);

        entity.HasOne(d => d.Person)
            .WithMany(i => i.PersonInterests)
            .HasForeignKey(d => d.PersonId)
            .OnDelete(DeleteBehavior.ClientSetNull);
      });

      modelBuilder.Seed();
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<Interest> Interests { get; set; }
    public DbSet<PersonInterest> PersonInterests { get; set; }
  }
}
