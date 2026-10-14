using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subtitle",
                value: "Junior Software Developer building backend features in C#/.NET and SQL Server. Responsible for development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM. Building a .NET 10 Web API on Azure as a personal project, with documented architecture decisions and secretless CI/CD.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                column: "Subtitle",
                value: "Junior Software Developer building backend features in C#/.NET and SQL Server. Responsible for development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM. Building a .NET 10 Web API on Azure as a personal project, with documented architecture decisions and secretless CI/CD. Looking for a junior backend role in a team with strong engineering practices.");
        }
    }
}
