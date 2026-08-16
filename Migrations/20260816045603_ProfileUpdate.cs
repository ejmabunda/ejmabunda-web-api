using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class ProfileUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Profiles", table: "Profiles");
            migrationBuilder.DropColumn(name: "Id", table: "Profiles");

            migrationBuilder
                .AddColumn<int>(
                    name: "Id",
                    table: "Profiles",
                    type: "int",
                    nullable: false);

            migrationBuilder
                .AddPrimaryKey(name: "PK_Profiles", table: "Profiles", column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(name: "PK_Profiles", table: "Profiles");
            migrationBuilder.DropColumn(name: "Id", table: "Profiles");

            migrationBuilder
                .AddColumn<Guid>(
                    name: "Id",
                    table: "Profiles",
                    type: "uniqueidentifier",
                    nullable: false);

            migrationBuilder
                .AddPrimaryKey(name: "PK_Profiles", table: "Profiles", column: "Id");
        }
    }
}
