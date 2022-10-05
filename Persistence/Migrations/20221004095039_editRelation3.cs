using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class editRelation3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceHDRs_ItemsDTLs_ItemsDTLId",
                table: "InvoiceHDRs");

            migrationBuilder.DropIndex(
                name: "IX_InvoiceHDRs_ItemsDTLId",
                table: "InvoiceHDRs");

            migrationBuilder.DropColumn(
                name: "ItemsDTLId",
                table: "InvoiceHDRs");

            migrationBuilder.RenameColumn(
                name: "InvoiceId",
                table: "ItemsDTLs",
                newName: "InvoiceHDRId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsDTLs_InvoiceHDRId",
                table: "ItemsDTLs",
                column: "InvoiceHDRId");

            migrationBuilder.AddForeignKey(
                name: "FK_ItemsDTLs_InvoiceHDRs_InvoiceHDRId",
                table: "ItemsDTLs",
                column: "InvoiceHDRId",
                principalTable: "InvoiceHDRs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ItemsDTLs_InvoiceHDRs_InvoiceHDRId",
                table: "ItemsDTLs");

            migrationBuilder.DropIndex(
                name: "IX_ItemsDTLs_InvoiceHDRId",
                table: "ItemsDTLs");

            migrationBuilder.RenameColumn(
                name: "InvoiceHDRId",
                table: "ItemsDTLs",
                newName: "InvoiceId");

            migrationBuilder.AddColumn<int>(
                name: "ItemsDTLId",
                table: "InvoiceHDRs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceHDRs_ItemsDTLId",
                table: "InvoiceHDRs",
                column: "ItemsDTLId");

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceHDRs_ItemsDTLs_ItemsDTLId",
                table: "InvoiceHDRs",
                column: "ItemsDTLId",
                principalTable: "ItemsDTLs",
                principalColumn: "Id");
        }
    }
}
