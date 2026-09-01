using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedContentAndSkillJoinTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CertificationSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CertificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CertificationSkills_Certifications_CertificationId",
                        column: x => x.CertificationId,
                        principalTable: "Certifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceSkills",
                columns: table => new
                {
                    ExperienceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceSkills", x => new { x.ExperienceId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_ExperienceSkills_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QualificationSkills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    QualificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QualificationSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QualificationSkills_Qualifications_QualificationId",
                        column: x => x.QualificationId,
                        principalTable: "Qualifications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QualificationSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Description", "Employer", "EndDate", "JobTitle", "StartDate" },
                values: new object[,]
                {
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), "Responsible for backend development and production support for an end-to-end recruitment platform serving the Department of Correctional Services — vacancy creation through interviews, panel scoring, and offers, live in production.\r\nBuilt an automated interview-scheduling feature (C#/.NET, Ical.Net) that distributes scoring links and calendar invites to panel members automatically, eliminating manual coordination for every interview cycle.\r\nRefactored a legacy JavaScript codebase into a state-driven architecture and introduced its first automated test suite (Jest) — including full coverage of multi-tier approval logic — cutting regression risk on the platform's most business-critical workflow.\r\nHandle production support for a live government system: diagnosed and resolved cross-stack issues including backend exceptions, async race conditions, and SQL correlated-subquery bugs. One fix resolved a document-classification defect that had been silently blocking candidates from submitting applications.\r\nBuilt backend API integrations connecting a candidate-facing portal to core CRM data.\r\nWrote and optimized SQL Server queries across recruitment data for reporting and root-cause investigations used in production incident response.\r\nDesigned cross-client HTML email templates (including Outlook/VML fallbacks) for automated candidate and panel communications.", "Xiquel Group", new DateTime(2027, 1, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "Junior Developer", new DateTime(2026, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"), "Mentored an incoming cohort of software engineering students alongside my own studies, supporting onboarding and technical growth.\r\nLed code pairing sessions and reviewed student submissions and commits, reinforcing software engineering best practices.\r\nFacilitated PechaKucha-style presentations to build mentees' communication and technical-storytelling skills.\r\nPartnered with the Student Performance team through standups and retrospectives to track mentee progress and escalate blockers.", "WeThinkCode_", new DateTime(2025, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Volunteer Technical Mentor", new DateTime(2025, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name", "SkillCategory" },
                values: new object[,]
                {
                    { new Guid("1be17dbe-55a5-4e3b-89f9-08df07c4f846"), "Jest", 3 },
                    { new Guid("24e71b43-a73b-4b25-89fa-08df07c4f846"), "Automated test suite design", 3 },
                    { new Guid("2571f576-4632-40ef-89ff-08df07c4f846"), "CI/CD pipelines", 4 },
                    { new Guid("39da40c1-f90f-497c-89eb-08df07c4f846"), "ASP.NET Web API", 0 },
                    { new Guid("42745c25-fdae-41fc-89f8-08df07c4f846"), "Form scripting", 2 },
                    { new Guid("5234d9f0-c4e1-4c88-89ec-08df07c4f846"), "REST", 0 },
                    { new Guid("53b177d5-f4af-42b2-89fd-08df07c4f846"), "Code review", 3 },
                    { new Guid("7154a018-bd1d-4e0d-89f1-08df07c4f846"), "SQL Server", 1 },
                    { new Guid("78ce5d51-f878-43aa-89f5-08df07c4f846"), "Dynamics 365 / CRM", 2 },
                    { new Guid("797d239c-f2db-49a8-8a00-08df07c4f846"), "Docker", 4 },
                    { new Guid("79d1cdb5-2238-4cfa-89f2-08df07c4f846"), "Process Automation", 1 },
                    { new Guid("9353a742-5ebc-44bb-8a02-08df07c4f846"), "GitHub", 4 },
                    { new Guid("9d2f95fb-2e19-4a8b-89f7-08df07c4f846"), "Execute Requests", 2 },
                    { new Guid("9f1ac98a-d659-4bb5-afe8-b5b859516f59"), "AWS (CloudFormation, ECS, Fargate)", 4 },
                    { new Guid("a34486d1-1e35-4e6b-89f3-08df07c4f846"), "Data Modelling", 1 },
                    { new Guid("a8bae3cb-b0b9-4353-89fb-08df07c4f846"), "Incident triage", 3 },
                    { new Guid("b3b43267-e5dd-4056-89ef-08df07c4f846"), "JavaScript (ES6+)", 0 },
                    { new Guid("b60764e1-2f14-4cf5-89ed-08df07c4f846"), "JSON", 0 },
                    { new Guid("b87602ae-295b-4eba-89f0-08df07c4f846"), "Python", 0 },
                    { new Guid("b8e3d00e-79aa-4c23-89f6-08df07c4f846"), "Plugins", 2 },
                    { new Guid("bce7603b-066c-4e06-89fc-08df07c4f846"), "Root-cause analysis", 3 },
                    { new Guid("ce5b9aae-4136-4004-89f4-08df07c4f846"), "API Integrations", 1 },
                    { new Guid("da81dc14-30c0-4a77-89ee-08df07c4f846"), "T-SQL", 0 },
                    { new Guid("ea5743a7-0df7-4956-8a01-08df07c4f846"), "Git", 4 },
                    { new Guid("f12ba2b4-e019-4cdf-89ea-08df07c4f846"), ".NET", 0 },
                    { new Guid("ff87c78a-3a06-4160-89e9-08df07c4f846"), "C#", 0 }
                });

            migrationBuilder.InsertData(
                table: "ExperienceSkills",
                columns: new[] { "ExperienceId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("1be17dbe-55a5-4e3b-89f9-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("24e71b43-a73b-4b25-89fa-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("7154a018-bd1d-4e0d-89f1-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("78ce5d51-f878-43aa-89f5-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("79d1cdb5-2238-4cfa-89f2-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("a8bae3cb-b0b9-4353-89fb-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("b3b43267-e5dd-4056-89ef-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("bce7603b-066c-4e06-89fc-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("ce5b9aae-4136-4004-89f4-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("da81dc14-30c0-4a77-89ee-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("f12ba2b4-e019-4cdf-89ea-08df07c4f846") },
                    { new Guid("00116dbb-6810-421c-a703-aecfe9872f77"), new Guid("ff87c78a-3a06-4160-89e9-08df07c4f846") },
                    { new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"), new Guid("53b177d5-f4af-42b2-89fd-08df07c4f846") },
                    { new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"), new Guid("ea5743a7-0df7-4956-8a01-08df07c4f846") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_CertificationSkills_CertificationId",
                table: "CertificationSkills",
                column: "CertificationId");

            migrationBuilder.CreateIndex(
                name: "IX_CertificationSkills_SkillId",
                table: "CertificationSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceSkills_SkillId",
                table: "ExperienceSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_ProjectId",
                table: "ProjectSkills",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectSkills_SkillId",
                table: "ProjectSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationSkills_QualificationId",
                table: "QualificationSkills",
                column: "QualificationId");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationSkills_SkillId",
                table: "QualificationSkills",
                column: "SkillId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CertificationSkills");

            migrationBuilder.DropTable(
                name: "ExperienceSkills");

            migrationBuilder.DropTable(
                name: "ProjectSkills");

            migrationBuilder.DropTable(
                name: "QualificationSkills");

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("00116dbb-6810-421c-a703-aecfe9872f77"));

            migrationBuilder.DeleteData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("7bba2264-b1df-48af-bfed-f1ca1c27fe95"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("1be17dbe-55a5-4e3b-89f9-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("24e71b43-a73b-4b25-89fa-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("2571f576-4632-40ef-89ff-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("39da40c1-f90f-497c-89eb-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("42745c25-fdae-41fc-89f8-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("5234d9f0-c4e1-4c88-89ec-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("53b177d5-f4af-42b2-89fd-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("7154a018-bd1d-4e0d-89f1-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("78ce5d51-f878-43aa-89f5-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("797d239c-f2db-49a8-8a00-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("79d1cdb5-2238-4cfa-89f2-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9353a742-5ebc-44bb-8a02-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9d2f95fb-2e19-4a8b-89f7-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("9f1ac98a-d659-4bb5-afe8-b5b859516f59"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a34486d1-1e35-4e6b-89f3-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("a8bae3cb-b0b9-4353-89fb-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b3b43267-e5dd-4056-89ef-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b60764e1-2f14-4cf5-89ed-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b87602ae-295b-4eba-89f0-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("b8e3d00e-79aa-4c23-89f6-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("bce7603b-066c-4e06-89fc-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ce5b9aae-4136-4004-89f4-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("da81dc14-30c0-4a77-89ee-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ea5743a7-0df7-4956-8a01-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("f12ba2b4-e019-4cdf-89ea-08df07c4f846"));

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: new Guid("ff87c78a-3a06-4160-89e9-08df07c4f846"));
        }
    }
}
