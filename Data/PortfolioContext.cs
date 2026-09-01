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
    public DbSet<QualificationSkill> QualificationSkills { get; set; } = null!;

    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ProjectSkill> ProjectSkills { get; set; } = null!;

    public DbSet<Experience> Experiences { get; set; } = null!;
    public DbSet<ExperienceSkill> ExperienceSkills { get; set; } = null!;

    public DbSet<Certification> Certifications { get; set; } = null!;
    public DbSet<CertificationSkill> CertificationSkills { get; set; } = null!;

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

        // seed experience
        modelBuilder.Entity<Experience>().HasData(
            new Experience
            {
                Id = new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"),
                JobTitle = "Volunteer Technical Mentor",
                Employer = "WeThinkCode_",
                StartDate = new DateTime(2025, 09, 01),
                EndDate = new DateTime(2025, 12, 10),
                Description = @"Mentored an incoming cohort of software engineering students alongside my own studies, supporting onboarding and technical growth.
Led code pairing sessions and reviewed student submissions and commits, reinforcing software engineering best practices.
Facilitated PechaKucha-style presentations to build mentees' communication and technical-storytelling skills.
Partnered with the Student Performance team through standups and retrospectives to track mentee progress and escalate blockers."
            }, new Experience
            {
                Id = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                JobTitle = "Junior Developer",
                Employer = "Xiquel Group",
                StartDate = new DateTime(2026, 02, 02),
                EndDate = new DateTime(2027, 01, 31),
                Description = @"Responsible for backend development and production support for an end-to-end recruitment platform serving the Department of Correctional Services — vacancy creation through interviews, panel scoring, and offers, live in production.
Built an automated interview-scheduling feature (C#/.NET, Ical.Net) that distributes scoring links and calendar invites to panel members automatically, eliminating manual coordination for every interview cycle.
Refactored a legacy JavaScript codebase into a state-driven architecture and introduced its first automated test suite (Jest) — including full coverage of multi-tier approval logic — cutting regression risk on the platform's most business-critical workflow.
Handle production support for a live government system: diagnosed and resolved cross-stack issues including backend exceptions, async race conditions, and SQL correlated-subquery bugs. One fix resolved a document-classification defect that had been silently blocking candidates from submitting applications.
Built backend API integrations connecting a candidate-facing portal to core CRM data.
Wrote and optimized SQL Server queries across recruitment data for reporting and root-cause investigations used in production incident response.
Designed cross-client HTML email templates (including Outlook/VML fallbacks) for automated candidate and panel communications."
            }
        );

        // seed skills
        modelBuilder.Entity<Skill>().HasData(
            // Languages & Backend
            new Skill { Id = new Guid("FF87C78A-3A06-4160-89E9-08DF07C4F846"), Name = "C#", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("F12BA2B4-E019-4CDF-89EA-08DF07C4F846"), Name = ".NET", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("39DA40C1-F90F-497C-89EB-08DF07C4F846"), Name = "ASP.NET Web API", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("5234D9F0-C4E1-4C88-89EC-08DF07C4F846"), Name = "REST", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("B60764E1-2F14-4CF5-89ED-08DF07C4F846"), Name = "JSON", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("DA81DC14-30C0-4A77-89EE-08DF07C4F846"), Name = "T-SQL", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("B3B43267-E5DD-4056-89EF-08DF07C4F846"), Name = "JavaScript (ES6+)", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("B87602AE-295B-4EBA-89F0-08DF07C4F846"), Name = "Python", SkillCategory = SkillCategory.LanguagesAndBackend },

            // Systems & Data
            new Skill { Id = new Guid("7154A018-BD1D-4E0D-89F1-08DF07C4F846"), Name = "SQL Server", SkillCategory = SkillCategory.SystemsAndData },
            new Skill { Id = new Guid("79D1CDB5-2238-4CFA-89F2-08DF07C4F846"), Name = "Process Automation", SkillCategory = SkillCategory.SystemsAndData },
            new Skill { Id = new Guid("A34486D1-1E35-4E6B-89F3-08DF07C4F846"), Name = "Data Modelling", SkillCategory = SkillCategory.SystemsAndData },
            new Skill { Id = new Guid("CE5B9AAE-4136-4004-89F4-08DF07C4F846"), Name = "API Integrations", SkillCategory = SkillCategory.SystemsAndData },

            // Platform
            new Skill { Id = new Guid("78CE5D51-F878-43AA-89F5-08DF07C4F846"), Name = "Dynamics 365 / CRM", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("B8E3D00E-79AA-4C23-89F6-08DF07C4F846"), Name = "Plugins", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("9D2F95FB-2E19-4A8B-89F7-08DF07C4F846"), Name = "Execute Requests", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("42745C25-FDAE-41FC-89F8-08DF07C4F846"), Name = "Form scripting", SkillCategory = SkillCategory.Platform },

            // Testing & Reliability
            new Skill { Id = new Guid("1BE17DBE-55A5-4E3B-89F9-08DF07C4F846"), Name = "Jest", SkillCategory = SkillCategory.TestingAndReliability },
            new Skill { Id = new Guid("24E71B43-A73B-4B25-89FA-08DF07C4F846"), Name = "Automated test suite design", SkillCategory = SkillCategory.TestingAndReliability },
            new Skill { Id = new Guid("A8BAE3CB-B0B9-4353-89FB-08DF07C4F846"), Name = "Incident triage", SkillCategory = SkillCategory.TestingAndReliability },
            new Skill { Id = new Guid("BCE7603B-066C-4E06-89FC-08DF07C4F846"), Name = "Root-cause analysis", SkillCategory = SkillCategory.TestingAndReliability },
            new Skill { Id = new Guid("53B177D5-F4AF-42B2-89FD-08DF07C4F846"), Name = "Code review", SkillCategory = SkillCategory.TestingAndReliability },

            // Cloud & DevOps
            new Skill { Id = new Guid("9f1ac98a-d659-4bb5-afe8-b5b859516f59"), Name = "AWS (CloudFormation, ECS, Fargate)", SkillCategory = SkillCategory.CloudAndDevOps },
            new Skill { Id = new Guid("2571F576-4632-40EF-89FF-08DF07C4F846"), Name = "CI/CD pipelines", SkillCategory = SkillCategory.CloudAndDevOps },
            new Skill { Id = new Guid("797D239C-F2DB-49A8-8A00-08DF07C4F846"), Name = "Docker", SkillCategory = SkillCategory.CloudAndDevOps },
            new Skill { Id = new Guid("EA5743A7-0DF7-4956-8A01-08DF07C4F846"), Name = "Git", SkillCategory = SkillCategory.CloudAndDevOps },
            new Skill { Id = new Guid("9353A742-5EBC-44BB-8A02-08DF07C4F846"), Name = "GitHub", SkillCategory = SkillCategory.CloudAndDevOps }
        );

        // seed experience skills
        modelBuilder.Entity<ExperienceSkill>()
            .HasKey(es => new { es.ExperienceId, es.SkillId });

        modelBuilder.Entity<ExperienceSkill>().HasData(
            // volunteer technical mentor, WTC
            new ExperienceSkill
            {
                ExperienceId = new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"),
                SkillId = new Guid("53B177D5-F4AF-42B2-89FD-08DF07C4F846")   // Code review
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"),
                SkillId = new Guid("EA5743A7-0DF7-4956-8A01-08DF07C4F846")   // Git
            },

            // junior developer, xiquel group
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("FF87C78A-3A06-4160-89E9-08DF07C4F846")   // C#
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("F12BA2B4-E019-4CDF-89EA-08DF07C4F846")   // .NET
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("B3B43267-E5DD-4056-89EF-08DF07C4F846")   // JavaScript (ES6+)
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("7154A018-BD1D-4E0D-89F1-08DF07C4F846")   // SQL Server
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("DA81DC14-30C0-4A77-89EE-08DF07C4F846")   // T-SQL
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("1BE17DBE-55A5-4E3B-89F9-08DF07C4F846")   // Jest
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("24E71B43-A73B-4B25-89FA-08DF07C4F846")   // Automated test suite design
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("79D1CDB5-2238-4CFA-89F2-08DF07C4F846")   // Process Automation
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("CE5B9AAE-4136-4004-89F4-08DF07C4F846")   // API Integrations
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("78CE5D51-F878-43AA-89F5-08DF07C4F846")   // Dynamics 365 / CRM
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("A8BAE3CB-B0B9-4353-89FB-08DF07C4F846")   // Incident triage
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("BCE7603B-066C-4E06-89FC-08DF07C4F846")   // Root-cause analysis
            }
        );
    }
}