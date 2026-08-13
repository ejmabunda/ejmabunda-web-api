using Microsoft.EntityFrameworkCore;

namespace ejmabunda_web_api.Models;

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
}