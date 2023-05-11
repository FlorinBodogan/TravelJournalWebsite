using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelJournalAPI.Server.Migrations
{
    public partial class _4Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Users_UserId",
                table: "Holidays");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Holidays",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "TEXT");

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Users_UserId",
                table: "Holidays",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_Users_UserId",
                table: "Holidays");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserId",
                table: "Holidays",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_Users_UserId",
                table: "Holidays",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
