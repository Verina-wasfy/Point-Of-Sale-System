using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Sales.Migrations
{
    public partial class firstmg : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Customer_ID = table.Column<int>(type: "int", nullable: false),
                    FName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone_Num = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Customer_ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoice_Details",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: false),
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    TPrice_PerTotalItems = table.Column<double>(type: "float", nullable: false),
                    TQuantity_PerItem = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice_Details", x => new { x.Item_ID, x.Invoice_ID });
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Item_ID = table.Column<int>(type: "int", nullable: false),
                    Item_Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<bool>(type: "bit", nullable: false),
                    Unit_Price = table.Column<double>(type: "float", nullable: false),
                    Production_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Item_ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Invoice_ID = table.Column<int>(type: "int", nullable: false),
                    Invoice_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CX_ID = table.Column<int>(type: "int", nullable: false),
                    Total_Price = table.Column<double>(type: "float", nullable: false),
                    Total_Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Invoice_ID);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CX_ID",
                        column: x => x.CX_ID,
                        principalTable: "Customers",
                        principalColumn: "Customer_ID",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_ItemsItem_ID",
                table: "InvoiceItem",
                column: "ItemsItem_ID");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CX_ID",
                table: "Invoices",
                column: "CX_ID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoice_Details");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
