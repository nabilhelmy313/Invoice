using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class editRelation2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHDRs_ItemsDTLs_ItemsDTLId",
                table: "InvoiceHDRs");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsDTLId",
                table: "InvoiceHDRs",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHDRs_ItemsDTLs_ItemsDTLId",
                table: "InvoiceHDRs",
                column: "ItemsDTLId",
                principalTable: "ItemsDTLs",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHDRs_ItemsDTLs_ItemsDTLId",
                table: "InvoiceHDRs");

            migrationBuilder.AlterColumn<int>(
                name: "ItemsDTLId",
                table: "InvoiceHDRs",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHDRs_ItemsDTLs_ItemsDTLId",
                table: "InvoiceHDRs",
                column: "ItemsDTLId",
                principalTable: "ItemsDTLs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
