using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class AddFreelanceSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ExperienceSkills",
                columns: new[] { "ExperienceId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("2571f576-4632-40ef-89ff-08df07c4f846") },
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("6298e695-2d82-49d8-bb55-654025b48d40") },
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("b3b43267-e5dd-4056-89ef-08df07c4f846") },
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("ea5743a7-0df7-4956-8a01-08df07c4f846") }
                });

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"),
                columns: new[] { "Description", "Employer", "EndDate", "JobTitle", "StartDate" },
                values: new object[] { "Built the company website with React 18, TypeScript, Vite and Bootstrap 5: six responsive routed pages (React Router) centred on a product catalog of 11 ranges rendered from data, so ranges change without editing markup.\nAdded a services and projects showcase, a supplier-brands section, and a contact form with client-side validation.\nSet up a GitHub Actions CI/CD pipeline that builds on every push to main and deploys to the client's host over FTP, with credentials held in repository secrets.", "Amos Katlego Holdings", new DateTime(2023, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Freelance Web Developer", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "SkillCategory" },
                values: new object[,]
                {
                    { new Guid("4a8d0c97-6e2b-43f1-b5d9-70c1e8a2f364"), "Vite", 0 },
                    { new Guid("58c2f6e1-a043-4d97-9b7e-1e8d5a30c6f9"), "React Router", 0 },
                    { new Guid("b7e5d318-92af-4c60-8e1d-3f6a09c4b827"), "Bootstrap 5", 0 },
                    { new Guid("c3f1a7d2-5b84-4e19-9a36-2d7e8f4b1c05"), "React", 0 },
                    { new Guid("e92b6a40-1d7c-4f53-8b08-a5c4d3e71f92"), "TypeScript", 0 }
                });

            migrationBuilder.InsertData(
                table: "ExperienceSkills",
                columns: new[] { "ExperienceId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("4a8d0c97-6e2b-43f1-b5d9-70c1e8a2f364") },
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("58c2f6e1-a043-4d97-9b7e-1e8d5a30c6f9") },
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("b7e5d318-92af-4c60-8e1d-3f6a09c4b827") },
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("c3f1a7d2-5b84-4e19-9a36-2d7e8f4b1c05") },
                    { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("e92b6a40-1d7c-4f53-8b08-a5c4d3e71f92") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("2571f576-4632-40ef-89ff-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("4a8d0c97-6e2b-43f1-b5d9-70c1e8a2f364") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("58c2f6e1-a043-4d97-9b7e-1e8d5a30c6f9") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("6298e695-2d82-49d8-bb55-654025b48d40") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("b3b43267-e5dd-4056-89ef-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("b7e5d318-92af-4c60-8e1d-3f6a09c4b827") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("c3f1a7d2-5b84-4e19-9a36-2d7e8f4b1c05") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("e92b6a40-1d7c-4f53-8b08-a5c4d3e71f92") });

            migrationBuilder.DeleteData(
                table: "ExperienceSkills",
                keyColumns: new[] { "ExperienceId", "SkillId" },
                keyValues: new object[] { new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"), new Guid("ea5743a7-0df7-4956-8a01-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("4a8d0c97-6e2b-43f1-b5d9-70c1e8a2f364"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("58c2f6e1-a043-4d97-9b7e-1e8d5a30c6f9"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b7e5d318-92af-4c60-8e1d-3f6a09c4b827"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("c3f1a7d2-5b84-4e19-9a36-2d7e8f4b1c05"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("e92b6a40-1d7c-4f53-8b08-a5c4d3e71f92"));

            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("84fa5ef1-6683-4b3b-bbab-3e024755390e"),
                columns: new[] { "Description", "Employer", "EndDate", "JobTitle", "StartDate" },
                values: new object[] { "Responsible for backend development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM; resolve defects across C# plugins, JavaScript form logic, and SQL Server, including a document-classification defect that was silently blocking candidates from submitting applications.\nBuilt an interview-scheduling module (C#/.NET, Ical.Net) that sends scoring links and calendar invites for each recruitment cycle, replacing manual scheduling coordination.\nBuilt a .NET console application that imports National Treasury mSCOA data through the platform's execute-request API for a municipal finance system in development; the team uses it as the only method for loading this data.\nConfigure Dynamics 365 model-driven apps, forms, views, business process flows, and dashboards for a client.\nBuilt API integrations connecting a candidate-facing portal to CRM data, and wrote SQL Server queries for reporting.", "Xiquel Group", new DateTime(2026, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Developer", new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
