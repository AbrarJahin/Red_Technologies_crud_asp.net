using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    public partial class ManyToManyOrderProductAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveApplications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "XmlFiles",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "Orders",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    OrderType = table.Column<int>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_User_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 32767, nullable: false),
                    UnitPrice = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderProducts",
                schema: "public",
                columns: table => new
                {
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: false),
                    Id = table.Column<Guid>(nullable: true),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    UnitBought = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderProducts", x => new { x.OrderId, x.ProductId });
                    table.ForeignKey(
                        name: "FK_OrderProducts_Orders_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "public",
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderProducts_Product_ProductId",
                        column: x => x.ProductId,
                        principalSchema: "public",
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderProducts_ProductId",
                schema: "public",
                table: "OrderProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "public",
                table: "Orders",
                column: "CustomerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderProducts",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Orders",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "public");

            migrationBuilder.CreateTable(
                name: "XmlFiles",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    DbEntryId = table.Column<long>(type: "bigint", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    FileContent = table.Column<string>(type: "text", nullable: false),
                    FileRealName = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    IsAlreadyUsed = table.Column<bool>(type: "boolean", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    PreviousFileId = table.Column<Guid>(type: "uuid", nullable: true),
                    SignerId = table.Column<Guid>(type: "uuid", nullable: true),
                    TableName = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_XmlFiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_XmlFiles_XmlFiles_PreviousFileId",
                        column: x => x.PreviousFileId,
                        principalSchema: "public",
                        principalTable: "XmlFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_XmlFiles_User_SignerId",
                        column: x => x.SignerId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LeaveApplications",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AddressDuringLeave = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    ApplicantId = table.Column<Guid>(type: "uuid", nullable: true),
                    ApplicationStatus = table.Column<int>(type: "integer", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Designation = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    LastSignedId = table.Column<Guid>(type: "uuid", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    LeaveEnd = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LeaveStart = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    LeaveType = table.Column<int>(type: "integer", nullable: false),
                    ApplicantName = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false),
                    PhoneNoDuringLeave = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    PurposeOfLeave = table.Column<string>(type: "character varying(32767)", maxLength: 32767, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_User_ApplicantId",
                        column: x => x.ApplicantId,
                        principalSchema: "Identity",
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LeaveApplications_XmlFiles_LastSignedId",
                        column: x => x.LastSignedId,
                        principalSchema: "public",
                        principalTable: "XmlFiles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_ApplicantId",
                schema: "public",
                table: "LeaveApplications",
                column: "ApplicantId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveApplications_LastSignedId",
                schema: "public",
                table: "LeaveApplications",
                column: "LastSignedId");

            migrationBuilder.CreateIndex(
                name: "IX_XmlFiles_PreviousFileId",
                schema: "public",
                table: "XmlFiles",
                column: "PreviousFileId");

            migrationBuilder.CreateIndex(
                name: "IX_XmlFiles_SignerId",
                schema: "public",
                table: "XmlFiles",
                column: "SignerId");
        }
    }
}
