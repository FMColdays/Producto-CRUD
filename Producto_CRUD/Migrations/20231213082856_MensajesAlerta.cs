using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Producto_CRUD.Migrations
{
    /// <inheritdoc />
    public partial class MensajesAlerta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TiposProducto",
                columns: table => new
                {
                    id_tipo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_tipo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiposPro__CF901089CE48170C", x => x.id_tipo);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    id_producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_producto = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    descripcion_producto = table.Column<string>(type: "text", nullable: false),
                    precio = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    stock = table.Column<int>(type: "int", nullable: false),
                    id_tipo_producto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto__FF341C0DD9D7C8D6", x => x.id_producto);
                    table.ForeignKey(
                        name: "FK__Productos__id_ti__398D8EEE",
                        column: x => x.id_tipo_producto,
                        principalTable: "TiposProducto",
                        principalColumn: "id_tipo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Productos_id_tipo_producto",
                table: "Productos",
                column: "id_tipo_producto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "TiposProducto");
        }
    }
}
