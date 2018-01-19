using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Project10.Migrations
{
    public partial class roommodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_AspNetUsers_UserId1",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_UserId1",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Room");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Room",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Routine",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Coursecode = table.Column<string>(nullable: true),
                    Day = table.Column<string>(nullable: true),
                    Roomname = table.Column<string>(nullable: true),
                    Teacherinitial = table.Column<string>(nullable: true),
                    Time = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routine", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_UserId",
                table: "Room",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_AspNetUsers_UserId",
                table: "Room",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_AspNetUsers_UserId",
                table: "Room");

            migrationBuilder.DropTable(
                name: "Routine");

            migrationBuilder.DropIndex(
                name: "IX_Room_UserId",
                table: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Room",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Room",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_UserId1",
                table: "Room",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_AspNetUsers_UserId1",
                table: "Room",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
