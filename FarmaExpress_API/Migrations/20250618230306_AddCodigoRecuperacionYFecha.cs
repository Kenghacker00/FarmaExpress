using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaExpress_API.Migrations
{
    /// <inheritdoc />
    public partial class AddCodigoRecuperacionYFecha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CodigoGeneradoEn",
                table: "usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CodigoRecuperacion",
                table: "usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodigoGeneradoEn",
                table: "usuarios");

            migrationBuilder.DropColumn(
                name: "CodigoRecuperacion",
                table: "usuarios");
        }
    }
}
