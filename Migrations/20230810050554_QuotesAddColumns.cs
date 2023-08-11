using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApi.Migrations
{
    /// <inheritdoc />
    public partial class QuotesAddColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Quotes",
                type: "timestamp without time zone",
                defaultValueSql: "CURRENT_TIMESTAMP",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "From",
                table: "Quotes",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Quotes");

            migrationBuilder.DropColumn(
                name: "From",
                table: "Quotes");
        }
    }
}
