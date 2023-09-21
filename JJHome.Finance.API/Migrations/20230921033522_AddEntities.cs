using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JJHome.Finance.API.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EXPENSETYPES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSETYPES", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "LOANS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EFFECTIVEFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EFFECTIVETO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AMOUNTPERMONTH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LOANS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ORGANIZATIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ORGANIZATIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAVINGS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMOUNTPERMONTH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EFFECTIVEFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EFFECTIVETO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAVINGS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SUBSCRIPTIONS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AMOUNTPERMONTH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EFFECTIVEFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EFFECTIVETO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUBSCRIPTIONS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EXPENSES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EXPENSETYPEID = table.Column<int>(type: "int", nullable: false),
                    AMOUNT = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EXPENSES", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EXPENSES_EXPENSETYPES_EXPENSETYPEID",
                        column: x => x.EXPENSETYPEID,
                        principalTable: "EXPENSETYPES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SALARIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AMOUNTPERMONTH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EFFECTIVEFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EFFECTIVETO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ORGANIZATIONID = table.Column<int>(type: "int", nullable: false),
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
                name: "IX_EXPENSES_EXPENSETYPEID",
                table: "EXPENSES",
                column: "EXPENSETYPEID");

            migrationBuilder.CreateIndex(
                name: "IX_SALARIES_ORGANIZATIONID",
                table: "SALARIES",
                column: "ORGANIZATIONID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EXPENSES");

            migrationBuilder.DropTable(
                name: "LOANS");

            migrationBuilder.DropTable(
                name: "SALARIES");

            migrationBuilder.DropTable(
                name: "SAVINGS");

            migrationBuilder.DropTable(
                name: "SUBSCRIPTIONS");

            migrationBuilder.DropTable(
                name: "EXPENSETYPES");

            migrationBuilder.DropTable(
                name: "ORGANIZATIONS");
        }
    }
}
