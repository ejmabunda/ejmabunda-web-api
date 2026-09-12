using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class SeedProfileData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Profiles",
                columns: new[] { "Id", "Headline", "Subtitle", "Title" },
                values: new object[] { 1, "Full Stack .NET Developer", "Full Stack .NET Developer with production experience architecting ASP.NET Core APIs, automated CI/CD pipelines, and cloud-native infrastructure on Azure. Proven ability to stabilize legacy systems, implement automated testing, and deliver full end-to-end enterprise features. Strong foundation in C#, SQL Server, and modern React/Next.js frontend architectures.", "Software Developer" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
