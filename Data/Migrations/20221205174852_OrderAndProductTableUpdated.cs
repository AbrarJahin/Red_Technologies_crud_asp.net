using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
	public partial class OrderAndProductTableUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableUnit",
                schema: "public",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsApproved",
                schema: "public",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPaid",
                schema: "public",
                table: "Orders",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<float>(
                name: "OrderTotal",
                schema: "public",
                table: "Orders",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableUnit",
                schema: "public",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsApproved",
                schema: "public",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "IsPaid",
                schema: "public",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                schema: "public",
                table: "Orders");
        }
    }
}
