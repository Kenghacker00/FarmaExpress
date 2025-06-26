using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FarmaExpress_API.Migrations
{
    /// <inheritdoc />
    public partial class Precision : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_categorias_categoriaId",
                table: "productos");

            migrationBuilder.DropForeignKey(
                name: "FK_productos_pedidos_PedidoId",
                table: "productos");

            migrationBuilder.DropIndex(
                name: "IX_productos_PedidoId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "PedidoId",
                table: "productos");

            migrationBuilder.DropColumn(
                name: "CantidadPedido",
                table: "pedidos");

            migrationBuilder.RenameColumn(
                name: "Gmail",
                table: "usuarios",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "categoriaId",
                table: "productos",
                newName: "CategoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_productos_categoriaId",
                table: "productos",
                newName: "IX_productos_CategoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "productos",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "PedidoDetalle",
                columns: table => new
                {
                    PedidoDetalleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PedidoId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PedidoDetalle", x => x.PedidoDetalleId);
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_pedidos_PedidoId",
                        column: x => x.PedidoId,
                        principalTable: "pedidos",
                        principalColumn: "PedidoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PedidoDetalle_productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "productos",
                        principalColumn: "ProductoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_PedidoId",
                table: "PedidoDetalle",
                column: "PedidoId");

            migrationBuilder.CreateIndex(
                name: "IX_PedidoDetalle_ProductoId",
                table: "PedidoDetalle",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_categorias_CategoriaId",
                table: "productos",
                column: "CategoriaId",
                principalTable: "categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productos_categorias_CategoriaId",
                table: "productos");

            migrationBuilder.DropTable(
                name: "PedidoDetalle");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "usuarios",
                newName: "Gmail");

            migrationBuilder.RenameColumn(
                name: "CategoriaId",
                table: "productos",
                newName: "categoriaId");

            migrationBuilder.RenameIndex(
                name: "IX_productos_CategoriaId",
                table: "productos",
                newName: "IX_productos_categoriaId");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "productos",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<int>(
                name: "PedidoId",
                table: "productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CantidadPedido",
                table: "pedidos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_productos_PedidoId",
                table: "productos",
                column: "PedidoId");

            migrationBuilder.AddForeignKey(
                name: "FK_productos_categorias_categoriaId",
                table: "productos",
                column: "categoriaId",
                principalTable: "categorias",
                principalColumn: "CategoriaId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productos_pedidos_PedidoId",
                table: "productos",
                column: "PedidoId",
                principalTable: "pedidos",
                principalColumn: "PedidoId");
        }
    }
}
