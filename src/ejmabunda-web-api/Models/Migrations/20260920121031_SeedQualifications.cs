using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedQualifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationSkills",
                table: "QualificationSkills");

            migrationBuilder.DropIndex(
                name: "IX_QualificationSkills_QualificationId",
                table: "QualificationSkills");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "QualificationSkills");

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationSkills",
                table: "QualificationSkills",
                columns: new[] { "QualificationId", "SkillId" });

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subtitle",
                value: "Software Developer with production experience architecting ASP.NET Core APIs, automated CI/CD pipelines, and cloud-native infrastructure on Azure. Proven ability to stabilize legacy systems, implement automated testing, and deliver full end-to-end enterprise features. Strong foundation in C#, SQL Server, and modern React/Next.js frontend architectures.");

            migrationBuilder.InsertData(
                table: "Qualifications",
                columns: new[] { "Id", "EndDate", "Institution", "Name", "NqfLevel", "StartDate" },
                values: new object[,]
                {
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "WeThinkCode_", "Occupational Certificate: Software Engineer", 6, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("af1ca55f-3d3e-4a66-b743-cdd9b5bbba0c"), new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ponelopele Oracle Secondary School", "National Senior Certificate", 4, new DateTime(2017, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "QualificationSkills",
                columns: new[] { "QualificationId", "SkillId" },
                values: new object[,]
                {
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("24e71b43-a73b-4b25-89fa-08df07c4f846") },
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("2571f576-4632-40ef-89ff-08df07c4f846") },
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("53b177d5-f4af-42b2-89fd-08df07c4f846") },
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("7154a018-bd1d-4e0d-89f1-08df07c4f846") },
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("9f1ac98a-d659-4bb5-afe8-b5b859516f59") },
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("a34486d1-1e35-4e6b-89f3-08df07c4f846") },
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("b87602ae-295b-4eba-89f0-08df07c4f846") },
                    { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("da81dc14-30c0-4a77-89ee-08df07c4f846") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_QualificationSkills",
                table: "QualificationSkills");

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("24e71b43-a73b-4b25-89fa-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("2571f576-4632-40ef-89ff-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("53b177d5-f4af-42b2-89fd-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("7154a018-bd1d-4e0d-89f1-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("9f1ac98a-d659-4bb5-afe8-b5b859516f59") });

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("a34486d1-1e35-4e6b-89f3-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("b87602ae-295b-4eba-89f0-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "QualificationSkills",
                keyColumns: new[] { "QualificationId", "SkillId" },
                keyValues: new object[] { new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"), new Guid("da81dc14-30c0-4a77-89ee-08df07c4f846") });

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("af1ca55f-3d3e-4a66-b743-cdd9b5bbba0c"));

            migrationBuilder.DeleteData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"));

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "QualificationSkills",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_QualificationSkills",
                table: "QualificationSkills",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subtitle",
                value: "Software Developer Developer with production experience architecting ASP.NET Core APIs, automated CI/CD pipelines, and cloud-native infrastructure on Azure. Proven ability to stabilize legacy systems, implement automated testing, and deliver full end-to-end enterprise features. Strong foundation in C#, SQL Server, and modern React/Next.js frontend architectures.");

            migrationBuilder.CreateIndex(
                name: "IX_QualificationSkills_QualificationId",
                table: "QualificationSkills",
                column: "QualificationId");
        }
    }
}
