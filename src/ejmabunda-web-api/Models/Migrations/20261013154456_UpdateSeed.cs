using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                column: "Name",
                value: "Occupational Certificate: Software Engineering");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("ed318d65-52c0-47a2-a559-924c2563b482"),
                column: "Name",
                value: "BSc Computer Science (not completed)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("a774c9bc-61f5-4309-a53a-4da9d11494ec"),
                column: "Name",
                value: "Occupational Certificate: Software Engineering (with distinction)");

            migrationBuilder.UpdateData(
                table: "Qualifications",
                keyColumn: "Id",
                keyValue: new Guid("ed318d65-52c0-47a2-a559-924c2563b482"),
                column: "Name",
                value: "BSc Computer Science (coursework, not completed)");
        }
    }
}
