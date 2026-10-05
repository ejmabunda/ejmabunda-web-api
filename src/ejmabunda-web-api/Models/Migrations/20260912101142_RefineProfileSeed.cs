using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class RefineProfileSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                column: "Description",
                value: "Responsible for backend development and production support for an end-to-end recruitment platform, from vacancy creation through interviews, panel scoring, and offers, live in production.\r\nBuilt an automated interview-scheduling feature (C#/.NET, Ical.Net) that distributes scoring links and calendar invites to panel members automatically, eliminating manual coordination for every interview cycle.\r\nRefactored a legacy JavaScript codebase into a state-driven architecture and introduced its first automated test suite (Jest) — including full coverage of multi-tier approval logic — cutting regression risk on the platform's most business-critical workflow.\r\nHandle production support for a live, high-traffic system: diagnosed and resolved cross-stack issues including backend exceptions, async race conditions, and SQL correlated-subquery bugs. One fix resolved a document-classification defect that had been silently blocking candidates from submitting applications.\r\nBuilt backend API integrations connecting a candidate-facing portal to core CRM data.\r\nWrote and optimized SQL Server queries across recruitment data for reporting and root-cause investigations used in production incident response.\r\nDesigned cross-client HTML email templates (including Outlook/VML fallbacks) for automated candidate and panel communications.");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Headline", "Subtitle", "Title" },
                values: new object[] { "Software Developer", "Software Developer Developer with production experience architecting ASP.NET Core APIs, automated CI/CD pipelines, and cloud-native infrastructure on Azure. Proven ability to stabilize legacy systems, implement automated testing, and deliver full end-to-end enterprise features. Strong foundation in C#, SQL Server, and modern React/Next.js frontend architectures.", "Matimu Mabunda" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                column: "Description",
                value: "Responsible for backend development and production support for an end-to-end recruitment platform, from vacancy creation through interviews, panel scoring, and offers, live in production.\r\nBuilt an automated interview-scheduling feature (C#/.NET, Ical.Net) that distributes scoring links and calendar invites to panel members automatically, eliminating manual coordination for every interview cycle.\r\nRefactored a legacy JavaScript codebase into a state-driven architecture and introduced its first automated test suite (Jest) — including full coverage of multi-tier approval logic — cutting regression risk on the platform's most business-critical workflow.\r\nHandle production support for a live, high-traffic system: diagnosed and resolved cross-stack issues including backend exceptions, async race conditions, and SQL correlated-subquery bugs. One fix resolved a document-classification defect that had been silently blocking candidates from submitting applications.\r\nBuilt backend API integrations connecting a candidate-facing portal to core CRM data.\r\nWrote and optimized SQL Server queries across recruitment data for reporting and root-cause investigations used in production incident response.\r\nDesigned cross-client HTML email templates (including Outlook/VML fallbacks) for automated candidate and panel communications.");

            migrationBuilder.UpdateData(
                table: "Profiles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Headline", "Subtitle", "Title" },
                values: new object[] { "Full Stack .NET Developer", "Full Stack .NET Developer with production experience architecting ASP.NET Core APIs, automated CI/CD pipelines, and cloud-native infrastructure on Azure. Proven ability to stabilize legacy systems, implement automated testing, and deliver full end-to-end enterprise features. Strong foundation in C#, SQL Server, and modern React/Next.js frontend architectures.", "Software Developer" });
        }
    }
}
