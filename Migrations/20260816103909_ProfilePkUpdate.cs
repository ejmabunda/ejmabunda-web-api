using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ejmabunda_web_api.Migrations
{
    /// <inheritdoc />
    public partial class ProfilePkUpdate : Migration
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
                    nullable: false,
                    type: "int"
                );
            migrationBuilder.AddPrimaryKey("PK_Profiles", "Profiles", "Id");
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
                    nullable: false,
                    type: "uniqueidentifier"
                );
            migrationBuilder.AddPrimaryKey("PK_Profiles", "Profiles", "Id");
        }
    }
}
