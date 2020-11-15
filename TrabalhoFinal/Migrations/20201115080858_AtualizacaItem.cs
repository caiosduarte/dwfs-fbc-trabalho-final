using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Inventario.Migrations
{
    public partial class AtualizacaItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataUltimaAtualizacao",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Item",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(7)",
                oldMaxLength: 7);

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Item",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Custo",
                table: "Item",
                type: "money",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(19,4)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AtualizadoEm",
                table: "Item",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "ItemViewModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<string>(maxLength: 7, nullable: false),
                    Descricao = table.Column<string>(maxLength: 30, nullable: false),
                    Localizacao = table.Column<string>(maxLength: 10, nullable: true),
                    Custo = table.Column<decimal>(nullable: false),
                    ValorResidual = table.Column<decimal>(nullable: true),
                    Anos = table.Column<int>(nullable: false),
                    Depreciacao = table.Column<decimal>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: false),
                    DataUltimaAtualizacao = table.Column<DateTime>(nullable: false),
                    itemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemViewModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemViewModel_Item_itemId",
                        column: x => x.itemId,
                        principalTable: "Item",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemViewModel_itemId",
                table: "ItemViewModel",
                column: "itemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemViewModel");

            migrationBuilder.DropColumn(
                name: "AtualizadoEm",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Numero",
                table: "Item",
                type: "nvarchar(7)",
                maxLength: 7,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Localizacao",
                table: "Item",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "Custo",
                table: "Item",
                type: "decimal(19,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "money",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DataUltimaAtualizacao",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
