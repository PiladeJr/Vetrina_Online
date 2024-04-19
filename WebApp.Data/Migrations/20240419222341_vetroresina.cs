using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp.Context.Migrations
{
    public partial class vetroresina : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodotti_Lista_IDLista",
                table: "Prodotti");

            migrationBuilder.DropTable(
                name: "Lista");

            migrationBuilder.RenameColumn(
                name: "IDLista",
                table: "Prodotti",
                newName: "IDNegozio");

            migrationBuilder.RenameIndex(
                name: "IX_Prodotti_IDLista",
                table: "Prodotti",
                newName: "IX_Prodotti_IDNegozio");

            migrationBuilder.CreateTable(
                name: "Negozio",
                columns: table => new
                {
                    IDNegozio = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Negozio", x => x.IDNegozio);
                });

            migrationBuilder.CreateTable(
                name: "Ordini",
                columns: table => new
                {
                    IDOrdine = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordini", x => x.IDOrdine);
                    table.ForeignKey(
                        name: "FK_Ordini_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProdottiOrdinati",
                columns: table => new
                {
                    IDProdottoOrdinato = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantità = table.Column<int>(type: "int", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    IDProdotto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDOrdine = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdottiOrdinati", x => x.IDProdottoOrdinato);
                    table.ForeignKey(
                        name: "FK_ProdottiOrdinati_Ordini_IDOrdine",
                        column: x => x.IDOrdine,
                        principalTable: "Ordini",
                        principalColumn: "IDOrdine",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdottiOrdinati_Prodotti_IDProdotto",
                        column: x => x.IDProdotto,
                        principalTable: "Prodotti",
                        principalColumn: "IDProdotto",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ordini_Id",
                table: "Ordini",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ProdottiOrdinati_IDOrdine",
                table: "ProdottiOrdinati",
                column: "IDOrdine");

            migrationBuilder.CreateIndex(
                name: "IX_ProdottiOrdinati_IDProdotto",
                table: "ProdottiOrdinati",
                column: "IDProdotto");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotti_Negozio_IDNegozio",
                table: "Prodotti",
                column: "IDNegozio",
                principalTable: "Negozio",
                principalColumn: "IDNegozio",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prodotti_Negozio_IDNegozio",
                table: "Prodotti");

            migrationBuilder.DropTable(
                name: "Negozio");

            migrationBuilder.DropTable(
                name: "ProdottiOrdinati");

            migrationBuilder.DropTable(
                name: "Ordini");

            migrationBuilder.RenameColumn(
                name: "IDNegozio",
                table: "Prodotti",
                newName: "IDLista");

            migrationBuilder.RenameIndex(
                name: "IX_Prodotti_IDNegozio",
                table: "Prodotti",
                newName: "IX_Prodotti_IDLista");

            migrationBuilder.CreateTable(
                name: "Lista",
                columns: table => new
                {
                    IDLista = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PrezzoTotale = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantitaProdotti = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lista", x => x.IDLista);
                    table.ForeignKey(
                        name: "FK_Lista_AspNetUsers_Id",
                        column: x => x.Id,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Lista_Id",
                table: "Lista",
                column: "Id",
                unique: true,
                filter: "[Id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodotti_Lista_IDLista",
                table: "Prodotti",
                column: "IDLista",
                principalTable: "Lista",
                principalColumn: "IDLista",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
