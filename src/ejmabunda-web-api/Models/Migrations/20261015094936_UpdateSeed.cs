using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExperienceSkills",
                columns: new[] { "ExperienceId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("42745c25-fdae-41fc-89f8-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("9d2f95fb-2e19-4a8b-89f7-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("b8e3d00e-79aa-4c23-89f6-08df07c4f846") }
                });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                columns: new[] { "Description", "EndDate" },
                values: new object[] { "Responsible for backend development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM; resolve defects across C# plugins, JavaScript form logic, and SQL Server, including a document-classification defect that was silently blocking candidates from submitting applications.\nBuilt an interview-scheduling module (C#/.NET, Ical.Net) that sends scoring links and calendar invites for each recruitment cycle, replacing manual scheduling coordination.\nBuilt a .NET console application that imports National Treasury mSCOA data through the platform's execute-request API for a municipal finance system in development; the team uses it as the only method for loading this data.\nConfigure Dynamics 365 model-driven apps, forms, views, business process flows, and dashboards for a client.\nBuilt API integrations connecting a candidate-facing portal to CRM data, and wrote SQL Server queries for reporting.", null });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"),
                column: "Description",
                value: "Mentored a cohort of software engineering students through technical onboarding, code-pairing sessions, and systematic commit reviews.");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Headline", "Subtitle" },
                values: new object[] { "Junior Software Developer, C# / .NET", "Junior Software Developer building backend features in C#/.NET and SQL Server. Responsible for development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM. Building a .NET 10 Web API on Azure as a personal project, with documented architecture decisions and secretless CI/CD." });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Name", "Url" },
                values: new object[] { new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), "Portfolio Web API", "https://github.com/ejmabunda/ejmabunda-web-api" });

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                columns: new[] { "EndDate", "Name" },
                values: new object[] { new DateTime(2026, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Occupational Certificate: Software Engineering" });

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "EndDate", "Institution", "Name", "NqfLevel", "StartDate" },
                values: new object[] { new Guid("ed318d65-52c0-47a2-a559-924c2563b482"), new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rhodes University", "BSc Computer Science (not completed)", 7, new DateTime(2018, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("39da40c1-f90f-497c-89eb-08df07c4f846"),
                column: "Name",
                value: "ASP.NET Core Web API");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5234d9f0-c4e1-4c88-89ec-08df07c4f846"),
                column: "Name",
                value: "REST APIs");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("78ce5d51-f878-43aa-89f5-08df07c4f846"),
                column: "Name",
                value: "Dynamics 365");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9353a742-5ebc-44bb-8a02-08df07c4f846"),
                column: "Name",
                value: "GitHub Actions (OIDC)");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b8e3d00e-79aa-4c23-89f6-08df07c4f846"),
                column: "Name",
                value: "Plugin development");

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "SkillCategory" },
                values: new object[,]
                {
                    { new Guid("355fe170-bea5-4614-8bc7-612a4711b345"), "Azure SQL Database", 4 },
                    { new Guid("43a1ee71-98ca-4ac1-bd8b-86f31daf5751"), "SSRS", 1 },
                    { new Guid("56760ee4-453b-41f8-b13b-f86f6ce0138e"), "Model-driven apps", 2 },
                    { new Guid("5859072a-ce48-4517-92a3-037a006e059c"), "Business process flows", 2 },
                    { new Guid("6298e695-2d82-49d8-bb55-654025b48d40"), "HTML/CSS", 0 },
                    { new Guid("9670c65e-a27e-459a-854d-19a3a950fb28"), "Azure App Service", 4 },
                    { new Guid("cec2f492-c370-4541-9779-655b7069aa0e"), "EF Core", 0 }
                });

            migrationBuilder.InsertData(
                table: "ExperienceSkills",
                columns: new[] { "ExperienceId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("56760ee4-453b-41f8-b13b-f86f6ce0138e") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("5859072a-ce48-4517-92a3-037a006e059c") }
                });

            migrationBuilder.InsertData(
                table: "ProjectSkills",
                columns: new[] { "Id", "ProjectId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("19b143e0-adac-46eb-a09f-e68bfa3d1632"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("9353a742-5ebc-44bb-8a02-08df07c4f846") },
                    { new Guid("32a31553-5a09-4615-a604-500d02afa236"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("9670c65e-a27e-459a-854d-19a3a950fb28") },
                    { new Guid("38bd0bca-ab67-4afb-b312-fffbbdb138e3"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("7154a018-bd1d-4e0d-89f1-08df07c4f846") },
                    { new Guid("73506565-b94b-4b85-8d8e-f15636202f0b"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("cec2f492-c370-4541-9779-655b7069aa0e") },
                    { new Guid("78c4154f-22cf-4d70-9ec4-1ca9697294fd"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("355fe170-bea5-4614-8bc7-612a4711b345") },
                    { new Guid("7d2fdd91-663c-44dd-8a7b-b9bde58e4df6"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("f12ba2b4-e019-4cdf-89ea-08df07c4f846") },
                    { new Guid("84f42022-65e8-42c3-aa53-da0306ca8d69"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("39da40c1-f90f-497c-89eb-08df07c4f846") },
                    { new Guid("915ca3bb-5451-4edc-a9e6-fe3ec0d2f652"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("2571f576-4632-40ef-89ff-08df07c4f846") },
                    { new Guid("adf3911a-6c93-4f13-aaa2-78a760e81fa3"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("5234d9f0-c4e1-4c88-89ec-08df07c4f846") },
                    { new Guid("db1b6b44-36d9-463e-bb25-5276add896ca"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("a34486d1-1e35-4e6b-89f3-08df07c4f846") },
                    { new Guid("faaba0a6-801f-42ae-a738-85e8f009e031"), new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"), new Guid("ff87c78a-3a06-4160-89e9-08df07c4f846") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("42745c25-fdae-41fc-89f8-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("56760ee4-453b-41f8-b13b-f86f6ce0138e") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("5859072a-ce48-4517-92a3-037a006e059c") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("9d2f95fb-2e19-4a8b-89f7-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("b8e3d00e-79aa-4c23-89f6-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("19b143e0-adac-46eb-a09f-e68bfa3d1632"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("32a31553-5a09-4615-a604-500d02afa236"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("38bd0bca-ab67-4afb-b312-fffbbdb138e3"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("73506565-b94b-4b85-8d8e-f15636202f0b"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("78c4154f-22cf-4d70-9ec4-1ca9697294fd"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("7d2fdd91-663c-44dd-8a7b-b9bde58e4df6"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("84f42022-65e8-42c3-aa53-da0306ca8d69"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("915ca3bb-5451-4edc-a9e6-fe3ec0d2f652"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("adf3911a-6c93-4f13-aaa2-78a760e81fa3"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("db1b6b44-36d9-463e-bb25-5276add896ca"));

            migrationBuilder.DeleteData(
                table: "ProjectSkills",
                keyColumn: "Id",
                keyValue: new Guid("faaba0a6-801f-42ae-a738-85e8f009e031"));

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("ed318d65-52c0-47a2-a559-924c2563b482"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("43a1ee71-98ca-4ac1-bd8b-86f31daf5751"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("6298e695-2d82-49d8-bb55-654025b48d40"));

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: new Guid("738d83e0-3dc5-4e48-a31d-129efcfd17d9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("355fe170-bea5-4614-8bc7-612a4711b345"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("56760ee4-453b-41f8-b13b-f86f6ce0138e"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5859072a-ce48-4517-92a3-037a006e059c"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9670c65e-a27e-459a-854d-19a3a950fb28"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("cec2f492-c370-4541-9779-655b7069aa0e"));

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                columns: new[] { "Description", "EndDate" },
                values: new object[] { "Responsible for backend development and production support for an end-to-end recruitment platform, from vacancy creation through interviews, panel scoring, and offers, live in production.\r\nBuilt an automated interview-scheduling feature (C#/.NET, Ical.Net) that distributes scoring links and calendar invites to panel members automatically, eliminating manual coordination for every interview cycle.\r\nRefactored a legacy JavaScript codebase into a state-driven architecture and introduced its first automated test suite (Jest) — including full coverage of multi-tier approval logic — cutting regression risk on the platform's most business-critical workflow.\r\nHandle production support for a live, high-traffic system: diagnosed and resolved cross-stack issues including backend exceptions, async race conditions, and SQL correlated-subquery bugs. One fix resolved a document-classification defect that had been silently blocking candidates from submitting applications.\r\nBuilt backend API integrations connecting a candidate-facing portal to core CRM data.\r\nWrote and optimized SQL Server queries across recruitment data for reporting and root-cause investigations used in production incident response.\r\nDesigned cross-client HTML email templates (including Outlook/VML fallbacks) for automated candidate and panel communications.", new DateTime(2027, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"),
                column: "Description",
                value: "Mentored an incoming cohort of software engineering students alongside my own studies, supporting onboarding and technical growth.\r\nLed code pairing sessions and reviewed student submissions and commits, reinforcing software engineering best practices.\r\nFacilitated PechaKucha-style presentations to build mentees' communication and technical-storytelling skills.\r\nPartnered with the Student Performance team through standups and retrospectives to track mentee progress and escalate blockers.");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Headline", "Subtitle" },
                values: new object[] { "Software Developer", "Software Developer with production experience architecting ASP.NET Core APIs, automated CI/CD pipelines, and cloud-native infrastructure on Azure. Proven ability to stabilize legacy systems, implement automated testing, and deliver full end-to-end enterprise features. Strong foundation in C#, SQL Server, and modern React/Next.js frontend architectures." });

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                columns: new[] { "EndDate", "Name" },
                values: new object[] { new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Occupational Certificate: Software Engineer" });

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("39da40c1-f90f-497c-89eb-08df07c4f846"),
                column: "Name",
                value: "ASP.NET Web API");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5234d9f0-c4e1-4c88-89ec-08df07c4f846"),
                column: "Name",
                value: "REST");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("78ce5d51-f878-43aa-89f5-08df07c4f846"),
                column: "Name",
                value: "Dynamics 365 / CRM");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9353a742-5ebc-44bb-8a02-08df07c4f846"),
                column: "Name",
                value: "GitHub");

            migrationBuilder.UpdateData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b8e3d00e-79aa-4c23-89f6-08df07c4f846"),
                column: "Name",
                value: "Plugins");
        }
    }
}
