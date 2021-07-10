using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Migrations
{
    public partial class dbchanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllInvoiceModelItem");

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    InvoicesInvoice_ID = table.Column<int>(type: "int", nullable: false),
                    ItemsItem_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => new { x.InvoicesInvoice_ID, x.ItemsItem_ID });
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoices_InvoicesInvoice_ID",
                        column: x => x.InvoicesInvoice_ID,
                        principalTable: "Invoices",
                        principalColumn: "Invoice_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Items_ItemsItem_ID",
                        column: x => x.ItemsItem_ID,
                        principalTable: "Items",
                        principalColumn: "Item_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_ItemsItem_ID",
                table: "InvoiceItem",
                column: "ItemsItem_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.CreateTable(
                name: "AllInvoiceModelItem",
                columns: table => new
                {
                    InvoicesInvoice_ID = table.Column<int>(type: "int", nullable: false),
                    ItemsItem_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllInvoiceModelItem", x => new { x.InvoicesInvoice_ID, x.ItemsItem_ID });
                    table.ForeignKey(
                        name: "FK_AllInvoiceModelItem_Invoices_InvoicesInvoice_ID",
                        column: x => x.InvoicesInvoice_ID,
                        principalTable: "Invoices",
                        principalColumn: "Invoice_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AllInvoiceModelItem_Items_ItemsItem_ID",
                        column: x => x.ItemsItem_ID,
                        principalTable: "Items",
                        principalColumn: "Item_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AllInvoiceModelItem_ItemsItem_ID",
                table: "AllInvoiceModelItem",
                column: "ItemsItem_ID");
        }
    }
}
