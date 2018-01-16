using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AtesBocegi.Data.Migrations
{
    public partial class articleordersadfsdf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ColorScale_ColorId",
                table: "Article");

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Article",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Article",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ColorScale_ColorId",
                table: "Article",
                column: "ColorId",
                principalTable: "ColorScale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Article_ColorScale_ColorId",
                table: "Article");

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "Article",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Image",
                table: "Article",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ColorId",
                table: "Article",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Article_ColorScale_ColorId",
                table: "Article",
                column: "ColorId",
                principalTable: "ColorScale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
