using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StartupProject_Asp.NetCore_PostGRE.Data.Migrations
{
    public partial class RemoveXmlTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveApplications",
                schema: "public");

            migrationBuilder.DropTable(
                name: "XmlFiles",
                schema: "public");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "XmlFiles",
                schema: "public",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    DbEntryId = table.Column<long>(type: "INTEGER", nullable: false),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    FileContent = table.Column<string>(type: "text", nullable: false),
                    FileRealName = table.Column<string>(type: "TEXT", maxLength: 32767, nullable: false),
                    IsAlreadyUsed = table.Column<bool>(type: "INTEGER", nullable: false),
                    LastUpdateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    PreviousFileId = table.Column<Guid>(type: "TEXT", nullable: true),
                    SignerId = table.Column<Guid>(type: "TEXT", nullable: true),
                    TableName = table.Column<int>(type: "INTEGER", nullable: false)
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
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    AddressDuringLeave = table.Column<string>(type: "TEXT", maxLength: 32767, nullable: false),
                    ApplicantId = table.Column<Guid>(type: "TEXT", nullable: true),
                    ApplicationStatus = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "TIMESTAMPTZ", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Designation = table.Column<string>(type: "TEXT", maxLength: 32767, nullable: false),
                    LastSignedId = table.Column<Guid>(type: "TEXT", nullable: true),
                    LastUpdateTime = table.Column<DateTime>(type: "TEXT", nullable: true),
                    LeaveEnd = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LeaveStart = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LeaveType = table.Column<int>(type: "INTEGER", nullable: false),
                    ApplicantName = table.Column<string>(type: "TEXT", maxLength: 32767, nullable: false),
                    PhoneNoDuringLeave = table.Column<string>(type: "TEXT", maxLength: 11, nullable: false),
                    PurposeOfLeave = table.Column<string>(type: "TEXT", maxLength: 32767, nullable: false)
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
