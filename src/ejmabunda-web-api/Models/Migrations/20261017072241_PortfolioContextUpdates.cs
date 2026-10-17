using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class PortfolioContextUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                column: "Description",
                value: "Responsible for backend development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM; resolve defects across C# plugins, JavaScript form logic, and SQL Server, including a document-classification defect that was silently blocking candidates from submitting applications.\r\nBuilt an interview-scheduling module (C#/.NET, Ical.Net) that sends scoring links and calendar invites for each recruitment cycle, replacing manual scheduling coordination.\r\nBuilt a .NET console application that imports National Treasury mSCOA data through the platform's execute-request API for a municipal finance system in development; the team uses it as the only method for loading this data.\r\nConfigure Dynamics 365 model-driven apps, forms, views, business process flows, and dashboards for a client.\r\nBuilt API integrations connecting a candidate-facing portal to CRM data, and wrote SQL Server queries for reporting.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Experiences",
                keyColumn: "Id",
                keyValue: new Guid("00116dbb-6810-421c-a703-aecfe9872f77"),
                column: "Description",
                value: "Responsible for backend development and production support on a live enterprise recruitment platform built on a Dynamics 365-inspired CRM; resolve defects across C# plugins, JavaScript form logic, and SQL Server, including a document-classification defect that was silently blocking candidates from submitting applications.\nBuilt an interview-scheduling module (C#/.NET, Ical.Net) that sends scoring links and calendar invites for each recruitment cycle, replacing manual scheduling coordination.\nBuilt a .NET console application that imports National Treasury mSCOA data through the platform's execute-request API for a municipal finance system in development; the team uses it as the only method for loading this data.\nConfigure Dynamics 365 model-driven apps, forms, views, business process flows, and dashboards for a client.\nBuilt API integrations connecting a candidate-facing portal to CRM data, and wrote SQL Server queries for reporting.");
        }
    }
}
