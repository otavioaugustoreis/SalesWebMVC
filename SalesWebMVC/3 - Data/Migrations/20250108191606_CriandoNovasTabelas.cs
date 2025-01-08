using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class CriandoNovasTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUCT",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DS_NOME = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NR_QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUCT", x => x.pk_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_VENDAPRODUTO",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    fk_salesrecord = table.Column<int>(type: "int", nullable: false),
                    fk_produto = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDAPRODUTO", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_TB_VENDAPRODUTO_TB_PRODUCT_fk_produto",
                        column: x => x.fk_produto,
                        principalTable: "TB_PRODUCT",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VENDAPRODUTO_TB_SALESRECORD_fk_salesrecord",
                        column: x => x.fk_salesrecord,
                        principalTable: "TB_SALESRECORD",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDAPRODUTO_fk_produto",
                table: "TB_VENDAPRODUTO",
                column: "fk_produto");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDAPRODUTO_fk_salesrecord",
                table: "TB_VENDAPRODUTO",
                column: "fk_salesrecord");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VENDAPRODUTO");

            migrationBuilder.DropTable(
                name: "TB_PRODUCT");
        }
    }
}
