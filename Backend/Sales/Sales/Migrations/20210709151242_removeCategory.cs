using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Migrations
{
    public partial class removeCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoryItem");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "Items_Categories");

            migrationBuilder.DropTable(
                name: "Categories");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AllInvoiceModelItem");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Category_Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Category_ID);
                });

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

            migrationBuilder.CreateTable(
                name: "Items_Categories",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: false),
                    Category_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_Categories", x => new { x.Item_ID, x.Category_ID });
                });

            migrationBuilder.CreateTable(
                name: "CategoryItem",
                columns: table => new
                {
                    CategoriesCategory_ID = table.Column<int>(type: "int", nullable: false),
                    ItemsItem_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryItem", x => new { x.CategoriesCategory_ID, x.ItemsItem_ID });
                    table.ForeignKey(
                        name: "FK_CategoryItem_Categories_CategoriesCategory_ID",
                        column: x => x.CategoriesCategory_ID,
                        principalTable: "Categories",
                        principalColumn: "Category_ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CategoryItem_Items_ItemsItem_ID",
                        column: x => x.ItemsItem_ID,
                        principalTable: "Items",
                        principalColumn: "Item_ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CategoryItem_ItemsItem_ID",
                table: "CategoryItem",
                column: "ItemsItem_ID");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_ItemsItem_ID",
                table: "InvoiceItem",
                column: "ItemsItem_ID");
        }
    }
}
