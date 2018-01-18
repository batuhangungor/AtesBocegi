using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AtesBocegi.Data.Migrations
{
    public partial class Employee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_ColorScale_ColorId",
                table: "Album");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Album",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Detail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Info = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ScreenOrder = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_ColorScale_ColorId",
                        column: x => x.ColorId,
                        principalTable: "ColorScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ColorId",
                table: "Employee",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_ColorScale_ColorId",
                table: "Album",
                column: "ColorId",
                principalTable: "ColorScale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Album_ColorScale_ColorId",
                table: "Album");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Album",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Album_ColorScale_ColorId",
                table: "Album",
                column: "ColorId",
                principalTable: "ColorScale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
