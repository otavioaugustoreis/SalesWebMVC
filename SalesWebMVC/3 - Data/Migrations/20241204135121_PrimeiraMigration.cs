using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SalesWebMVC.Migrations
{
    /// <inheritdoc />
    public partial class PrimeiraMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_DEPARTMENT",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_DEPARTMENT", x => x.pk_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_SELLER",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ds_email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ds_nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dh_aniversario = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    nr_salario = table.Column<double>(type: "double", nullable: false),
                    fk_departamento = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SELLER", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_TB_SELLER_TB_DEPARTMENT_fk_departamento",
                        column: x => x.fk_departamento,
                        principalTable: "TB_DEPARTMENT",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "TB_SALESRECORD",
                columns: table => new
                {
                    pk_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SaleStatus = table.Column<int>(type: "int", nullable: false),
                    ds_valor = table.Column<double>(type: "double", nullable: false),
                    fk_seller = table.Column<int>(type: "int", nullable: false),
                    dh_inclusao = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_SALESRECORD", x => x.pk_id);
                    table.ForeignKey(
                        name: "FK_TB_SALESRECORD_TB_SELLER_fk_seller",
                        column: x => x.fk_seller,
                        principalTable: "TB_SELLER",
                        principalColumn: "pk_id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SALESRECORD_fk_seller",
                table: "TB_SALESRECORD",
                column: "fk_seller");

            migrationBuilder.CreateIndex(
                name: "IX_TB_SELLER_fk_departamento",
                table: "TB_SELLER",
                column: "fk_departamento");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_SALESRECORD");

            migrationBuilder.DropTable(
                name: "TB_SELLER");

            migrationBuilder.DropTable(
                name: "TB_DEPARTMENT");
        }
    }
}
