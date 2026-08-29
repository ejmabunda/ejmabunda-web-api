using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Models;

/// <summary>EF Core context for the portfolio database (SQL Server), covering the domain entities in <c>Models/</c>.</summary>
public class PortfolioContext : DbContext
{
    public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
    {

    }

    public DbSet<Profile> Profiles { get; set; } = null!;
    public DbSet<Skill> Skills { get; set; } = null!;
    public DbSet<Qualification> Qualifications { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<Experience> Experiences { get; set; } = null!;
    public DbSet<Certification> Certifications { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Session> Sessions { get; set; } = null!;
    public DbSet<RefreshToken> RefreshTokens { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Profile is a singleton row (id fixed at 1, see Profile.Id), so EF must not
        // try to generate its own identity value for it.
        modelBuilder.Entity<Profile>(entity =>
            entity.Property(p => p.Id).ValueGeneratedNever()
        );

        // User is a singleton row (id fixed at 1, see User.Id), so EF must not
        // try to generate its own identity value for it.
        modelBuilder.Entity<User>(entity =>
            entity.Property(u => u.Id).ValueGeneratedNever()
        );
        
        modelBuilder.Entity<User>().HasData(new User
        {
            Id = 1,
            Username = "admin",
            PasswordHash = "AQAAAAIAAYagAAAAELEppuCtBGV1aw7+mVELYbgacYd9Cxhl1bmc/bx98ylwC8NshEbcsXrDUzulLq7f5Q=="
        });
    }
}