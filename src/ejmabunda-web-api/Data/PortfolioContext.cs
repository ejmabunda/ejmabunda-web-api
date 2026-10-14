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
        modelBuilder.Entity<Profile>().HasData(
            new Profile()
            {
                Title = "Matimu Mabunda",
                Headline = "Junior Software Developer, C# / .NET",
                Subtitle = "Junior Software Developer building backend features in C#/.NET and SQL Server. Responsible for development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM. Building a .NET 10 Web API on Azure as a personal project, with documented architecture decisions and secretless CI/CD."
            }
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
                Description = @"Mentored a cohort of software engineering students through technical onboarding, code-pairing sessions, and systematic commit reviews."
            }, new Experience
            {
                Id = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                JobTitle = "Junior Developer",
                Employer = "Xiquel Group",
                StartDate = new DateTime(2026, 02, 02),
                EndDate = null, // current role
                Description = @"Responsible for backend development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM; resolve defects across C# plugins, JavaScript form logic, and SQL Server, including a document-classification defect that was silently blocking candidates from submitting applications.
Built an interview-scheduling module (C#/.NET, Ical.Net) that sends scoring links and calendar invites for each recruitment cycle, replacing manual scheduling coordination.
Built a .NET console application that imports National Treasury mSCOA data through the platform's execute-request API for a municipal finance system in development; the team uses it as the only method for loading this data.
Configure Dynamics 365 model-driven apps, forms, views, business process flows, and dashboards for a client.
Built API integrations connecting a candidate-facing portal to CRM data, and wrote SQL Server queries for reporting."
            }
        );

        // seed skills
        modelBuilder.Entity<Skill>().HasData(
            // Languages & Backend
            new Skill { Id = new Guid("FF87C78A-3A06-4160-89E9-08DF07C4F846"), Name = "C#", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("F12BA2B4-E019-4CDF-89EA-08DF07C4F846"), Name = ".NET", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("39DA40C1-F90F-497C-89EB-08DF07C4F846"), Name = "ASP.NET Core Web API", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("5234D9F0-C4E1-4C88-89EC-08DF07C4F846"), Name = "REST APIs", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("B60764E1-2F14-4CF5-89ED-08DF07C4F846"), Name = "JSON", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("DA81DC14-30C0-4A77-89EE-08DF07C4F846"), Name = "T-SQL", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("B3B43267-E5DD-4056-89EF-08DF07C4F846"), Name = "JavaScript (ES6+)", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("B87602AE-295B-4EBA-89F0-08DF07C4F846"), Name = "Python", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("cec2f492-c370-4541-9779-655b7069aa0e"), Name = "EF Core", SkillCategory = SkillCategory.LanguagesAndBackend },
            new Skill { Id = new Guid("6298e695-2d82-49d8-bb55-654025b48d40"), Name = "HTML/CSS", SkillCategory = SkillCategory.LanguagesAndBackend },

            // Systems & Data
            new Skill { Id = new Guid("7154A018-BD1D-4E0D-89F1-08DF07C4F846"), Name = "SQL Server", SkillCategory = SkillCategory.SystemsAndData },
            new Skill { Id = new Guid("79D1CDB5-2238-4CFA-89F2-08DF07C4F846"), Name = "Process Automation", SkillCategory = SkillCategory.SystemsAndData },
            new Skill { Id = new Guid("A34486D1-1E35-4E6B-89F3-08DF07C4F846"), Name = "Data Modelling", SkillCategory = SkillCategory.SystemsAndData },
            new Skill { Id = new Guid("CE5B9AAE-4136-4004-89F4-08DF07C4F846"), Name = "API Integrations", SkillCategory = SkillCategory.SystemsAndData },
            new Skill { Id = new Guid("43a1ee71-98ca-4ac1-bd8b-86f31daf5751"), Name = "SSRS", SkillCategory = SkillCategory.SystemsAndData },

            // Platform
            new Skill { Id = new Guid("78CE5D51-F878-43AA-89F5-08DF07C4F846"), Name = "Dynamics 365", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("B8E3D00E-79AA-4C23-89F6-08DF07C4F846"), Name = "Plugin development", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("9D2F95FB-2E19-4A8B-89F7-08DF07C4F846"), Name = "Execute Requests", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("42745C25-FDAE-41FC-89F8-08DF07C4F846"), Name = "Form scripting", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("56760ee4-453b-41f8-b13b-f86f6ce0138e"), Name = "Model-driven apps", SkillCategory = SkillCategory.Platform },
            new Skill { Id = new Guid("5859072a-ce48-4517-92a3-037a006e059c"), Name = "Business process flows", SkillCategory = SkillCategory.Platform },

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
            new Skill { Id = new Guid("9353A742-5EBC-44BB-8A02-08DF07C4F846"), Name = "GitHub Actions (OIDC)", SkillCategory = SkillCategory.CloudAndDevOps },
            new Skill { Id = new Guid("9670c65e-a27e-459a-854d-19a3a950fb28"), Name = "Azure App Service", SkillCategory = SkillCategory.CloudAndDevOps },
            new Skill { Id = new Guid("355fe170-bea5-4614-8bc7-612a4711b345"), Name = "Azure SQL Database", SkillCategory = SkillCategory.CloudAndDevOps }
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
                SkillId = new Guid("78CE5D51-F878-43AA-89F5-08DF07C4F846")   // Dynamics 365
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
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("B8E3D00E-79AA-4C23-89F6-08DF07C4F846")   // Plugin development
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("9D2F95FB-2E19-4A8B-89F7-08DF07C4F846")   // Execute Requests
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("42745C25-FDAE-41FC-89F8-08DF07C4F846")   // Form scripting
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("56760ee4-453b-41f8-b13b-f86f6ce0138e")   // Model-driven apps
            },
            new ExperienceSkill
            {
                ExperienceId = new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                SkillId = new Guid("5859072a-ce48-4517-92a3-037a006e059c")   // Business process flows
            }
        );

        // seed qualifications
        modelBuilder.Entity<Qualification>().HasData(
            new Qualification
            {
                Id = new Guid("af1ca55f-3d3e-4a66-b743-cdd9b5bbba0c"),
                Name = "National Senior Certificate",
                Institution = "Ponelopele Oracle Secondary School",
                StartDate = new DateTime(2017, 12, 01),
                EndDate = new DateTime(2017, 12, 01),
                NqfLevel = NqfLevel.Grade12
            },
            new Qualification
            {
                Id = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                Name = "Occupational Certificate: Software Engineering",
                Institution = "WeThinkCode_",
                StartDate = new DateTime(2024, 01, 01),
                EndDate = new DateTime(2026, 01, 01),
                NqfLevel = NqfLevel.Diploma
            },
            new Qualification
            {
                Id = new Guid("ed318d65-52c0-47a2-a559-924c2563b482"),
                Name = "BSc Computer Science (not completed)",
                Institution = "Rhodes University",
                StartDate = new DateTime(2018, 01, 01),
                EndDate = new DateTime(2021, 12, 01),
                NqfLevel = NqfLevel.BachelorsDegree
            }
        );

        // seed qualification skills (the National Senior Certificate and Rhodes coursework have none)
        modelBuilder.Entity<QualificationSkill>()
            .HasKey(qs => new { qs.QualificationId, qs.SkillId });

        modelBuilder.Entity<QualificationSkill>().HasData(
            // occupational certificate: software engineer, WTC
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("B87602AE-295B-4EBA-89F0-08DF07C4F846")   // Python
            },
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("7154A018-BD1D-4E0D-89F1-08DF07C4F846")   // SQL Server
            },
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("DA81DC14-30C0-4A77-89EE-08DF07C4F846")   // T-SQL
            },
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("A34486D1-1E35-4E6B-89F3-08DF07C4F846")   // Data Modelling
            },
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("24E71B43-A73B-4B25-89FA-08DF07C4F846")   // Automated test suite design
            },
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("53B177D5-F4AF-42B2-89FD-08DF07C4F846")   // Code review
            },
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("2571F576-4632-40EF-89FF-08DF07C4F846")   // CI/CD pipelines
            },
            new QualificationSkill
            {
                QualificationId = new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                SkillId = new Guid("9f1ac98a-d659-4bb5-afe8-b5b859516f59")   // AWS (CloudFormation, ECS, Fargate)
            }
        );

        // seed projects
        modelBuilder.Entity<Project>().HasData(
            new Project
            {
                Id = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                Name = "Portfolio Web API",
                Url = "https://github.com/ejmabunda/ejmabunda-web-api"
            }
        );

        // seed project skills
        modelBuilder.Entity<ProjectSkill>().HasData(
            // portfolio web api
            new ProjectSkill
            {
                Id = new Guid("faaba0a6-801f-42ae-a738-85e8f009e031"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("FF87C78A-3A06-4160-89E9-08DF07C4F846")   // C#
            },
            new ProjectSkill
            {
                Id = new Guid("7d2fdd91-663c-44dd-8a7b-b9bde58e4df6"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("F12BA2B4-E019-4CDF-89EA-08DF07C4F846")   // .NET
            },
            new ProjectSkill
            {
                Id = new Guid("84f42022-65e8-42c3-aa53-da0306ca8d69"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("39DA40C1-F90F-497C-89EB-08DF07C4F846")   // ASP.NET Core Web API
            },
            new ProjectSkill
            {
                Id = new Guid("adf3911a-6c93-4f13-aaa2-78a760e81fa3"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("5234D9F0-C4E1-4C88-89EC-08DF07C4F846")   // REST APIs
            },
            new ProjectSkill
            {
                Id = new Guid("73506565-b94b-4b85-8d8e-f15636202f0b"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("cec2f492-c370-4541-9779-655b7069aa0e")   // EF Core
            },
            new ProjectSkill
            {
                Id = new Guid("38bd0bca-ab67-4afb-b312-fffbbdb138e3"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("7154A018-BD1D-4E0D-89F1-08DF07C4F846")   // SQL Server
            },
            new ProjectSkill
            {
                Id = new Guid("db1b6b44-36d9-463e-bb25-5276add896ca"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("A34486D1-1E35-4E6B-89F3-08DF07C4F846")   // Data Modelling
            },
            new ProjectSkill
            {
                Id = new Guid("32a31553-5a09-4615-a604-500d02afa236"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("9670c65e-a27e-459a-854d-19a3a950fb28")   // Azure App Service
            },
            new ProjectSkill
            {
                Id = new Guid("78c4154f-22cf-4d70-9ec4-1ca9697294fd"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("355fe170-bea5-4614-8bc7-612a4711b345")   // Azure SQL Database
            },
            new ProjectSkill
            {
                Id = new Guid("19b143e0-adac-46eb-a09f-e68bfa3d1632"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("9353A742-5EBC-44BB-8A02-08DF07C4F846")   // GitHub Actions (OIDC)
            },
            new ProjectSkill
            {
                Id = new Guid("915ca3bb-5451-4edc-a9e6-fe3ec0d2f652"),
                ProjectId = new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"),
                SkillId = new Guid("2571F576-4632-40EF-89FF-08DF07C4F846")   // CI/CD pipelines
            }
        );
    }
}
