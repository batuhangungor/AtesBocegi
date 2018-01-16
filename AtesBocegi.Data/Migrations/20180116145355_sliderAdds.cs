using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AtesBocegi.Data.Migrations
{
    public partial class sliderAdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "İmage",
                table: "albumItem");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "albumItem",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "albumItem");

            migrationBuilder.AddColumn<string>(
                name: "İmage",
                table: "albumItem",
                nullable: false,
                defaultValue: "");
        }
    }
}
