using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AtesBocegi.Data.Migrations
{
    public partial class about : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeftContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LeftTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RightTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Vision = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutUs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutUs");
        }
    }
}
