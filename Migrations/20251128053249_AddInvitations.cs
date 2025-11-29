using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PartyManager.Migrations
{
    /// <inheritdoc />
    public partial class AddInvitations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ResponseDate",
                table: "Invitations");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Invitations",
                newName: "Response");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Response",
                table: "Invitations",
                newName: "Status");

            migrationBuilder.AddColumn<DateTime>(
                name: "ResponseDate",
                table: "Invitations",
                type: "TEXT",
                nullable: true);
        }
    }
}
