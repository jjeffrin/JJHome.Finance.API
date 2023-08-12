using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JJHome.Finance.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMapFromSalaryEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SALARIES");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SALARIES",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ORGANIZATIONID = table.Column<int>(type: "int", nullable: false),
                    AMOUNTPERMONTH = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CREATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DISCRIMINATOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EFFECTIVEFROM = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EFFECTIVETO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATED_AT = table.Column<DateTime>(type: "datetime2", nullable: false),
                    USER_ID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DESCRIPTION = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
        }
    }
}
