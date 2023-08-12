using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JJHome.Finance.API.Migrations
{
    /// <inheritdoc />
    public partial class EntityCorrections2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_EXPENSETYPETYPE",
                table: "EXPENSES");

            migrationBuilder.DropIndex(
                name: "IX_ORGANIZATIONS_NAME",
                table: "ORGANIZATIONS");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXPENSETYPES",
                table: "EXPENSETYPES");

            migrationBuilder.DropIndex(
                name: "IX_EXPENSES_EXPENSETYPETYPE",
                table: "EXPENSES");

            migrationBuilder.DropColumn(
                name: "TYPE",
                table: "EXPENSETYPES");

            migrationBuilder.DropColumn(
                name: "EXPENSETYPETYPE",
                table: "EXPENSES");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ORGANIZATIONS",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ID",
                table: "EXPENSETYPES",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "CREATED_AT",
                table: "EXPENSETYPES",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "NAME",
                table: "EXPENSETYPES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UPDATED_AT",
                table: "EXPENSETYPES",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "USER_ID",
                table: "EXPENSETYPES",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EXPENSETYPEID",
                table: "EXPENSES",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXPENSETYPES",
                table: "EXPENSETYPES",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSES_EXPENSETYPEID",
                table: "EXPENSES",
                column: "EXPENSETYPEID");

            migrationBuilder.AddForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_EXPENSETYPEID",
                table: "EXPENSES",
                column: "EXPENSETYPEID",
                principalTable: "EXPENSETYPES",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_EXPENSETYPEID",
                table: "EXPENSES");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EXPENSETYPES",
                table: "EXPENSETYPES");

            migrationBuilder.DropIndex(
                name: "IX_EXPENSES_EXPENSETYPEID",
                table: "EXPENSES");

            migrationBuilder.DropColumn(
                name: "ID",
                table: "EXPENSETYPES");

            migrationBuilder.DropColumn(
                name: "CREATED_AT",
                table: "EXPENSETYPES");

            migrationBuilder.DropColumn(
                name: "NAME",
                table: "EXPENSETYPES");

            migrationBuilder.DropColumn(
                name: "UPDATED_AT",
                table: "EXPENSETYPES");

            migrationBuilder.DropColumn(
                name: "USER_ID",
                table: "EXPENSETYPES");

            migrationBuilder.DropColumn(
                name: "EXPENSETYPEID",
                table: "EXPENSES");

            migrationBuilder.AlterColumn<string>(
                name: "NAME",
                table: "ORGANIZATIONS",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "TYPE",
                table: "EXPENSETYPES",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EXPENSETYPETYPE",
                table: "EXPENSES",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EXPENSETYPES",
                table: "EXPENSETYPES",
                column: "TYPE");

            migrationBuilder.CreateIndex(
                name: "IX_ORGANIZATIONS_NAME",
                table: "ORGANIZATIONS",
                column: "NAME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EXPENSES_EXPENSETYPETYPE",
                table: "EXPENSES",
                column: "EXPENSETYPETYPE");

            migrationBuilder.AddForeignKey(
                name: "FK_EXPENSES_EXPENSETYPES_EXPENSETYPETYPE",
                table: "EXPENSES",
                column: "EXPENSETYPETYPE",
                principalTable: "EXPENSETYPES",
                principalColumn: "TYPE",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
