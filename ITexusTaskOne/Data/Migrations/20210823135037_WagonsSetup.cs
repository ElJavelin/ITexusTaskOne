using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ITexusTaskOne.Data.Migrations
{
    public partial class WagonsSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wagon",
                columns: table => new
                {
                    WagonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryNum = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    ProdDate = table.Column<DateTime>(nullable: false),
                    ExpDate = table.Column<DateTime>(nullable: false),
                    WagWeight = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wagon", x => x.WagonID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wagon");
        }
    }
}
