using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JJHome.Finance.API.Migrations
{
    /// <inheritdoc />
    public partial class EntityCorrections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_TYPE1",
                table: "EXPENSES");

            migrationBuilder.RenameColumn(
                name: "TYPE1",
                table: "EXPENSES",
                newName: "EXPENSETYPETYPE");

            migrationBuilder.RenameIndex(
                name: "IX_EXPENSES_TYPE1",
                table: "EXPENSES",
                newName: "IX_EXPENSES_EXPENSETYPETYPE");

            migrationBuilder.CreateTable(
                name: "SALARIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AMOUNTPERMONTH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EFFECTIVEFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EFFECTIVETO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ORGANIZATIONID = table.Column<int>(type: "int", nullable: false),
                    DISCRIMINATOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SALARIES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SALARIES_ORGANIZATIONS_ORGANIZATIONID",
                        column: x => x.ORGANIZATIONID,
                        principalTable: "ORGANIZATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SALARIES_ORGANIZATIONID",
                table: "SALARIES",
                column: "ORGANIZATIONID");

            migrationBuilder.AddForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_EXPENSETYPETYPE",
                table: "EXPENSES",
                column: "EXPENSETYPETYPE",
                principalTable: "EXPENSETYPES",
                principalColumn: "TYPE",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_EXPENSETYPETYPE",
                table: "EXPENSES");

            migrationBuilder.DropTable(
                name: "SALARIES");

            migrationBuilder.RenameColumn(
                name: "EXPENSETYPETYPE",
                table: "EXPENSES",
                newName: "TYPE1");

            migrationBuilder.RenameIndex(
                name: "IX_EXPENSES_EXPENSETYPETYPE",
                table: "EXPENSES",
                newName: "IX_EXPENSES_TYPE1");

            migrationBuilder.AddForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_TYPE1",
                table: "EXPENSES",
                column: "TYPE1",
                principalTable: "EXPENSETYPES",
                principalColumn: "TYPE",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
