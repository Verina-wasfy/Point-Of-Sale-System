using Microsoft.EntityFrameworkCore;
using Sales.Models;
using Sales.Services.Interfaces;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services
{
    public class AllInvoicesMoc : IAllInvoices
    {
        private ApiDbContext _db;
        public AllInvoicesMoc(ApiDbContext db)
        {
            _db = db;

        }
        public async Task<List<AllInvoicesModel>> GetAll()
        {
            var LoadAll = await _db.Invoices
                           .ToListAsync();
            var Len = _db.Invoices.Count();

            List<AllInvoicesModel> AllInvoices= new List<AllInvoicesModel>();

            for (int i=0; i < Len; i++)
            {
                var CstName = _db.Customers.Where(a => a.Customer_ID == LoadAll[i].CX_ID).Select(a=>a.FName).FirstOrDefault();

                AllInvoices.Add(new AllInvoicesModel()
                {
                    CX_Name = CstName,
                    Invoice_Date = LoadAll[i].Invoice_Date,
                    Invoice_ID = LoadAll[i].Invoice_ID,
                    Total_Price = LoadAll[i].Total_Price,
                    Total_Quantity = LoadAll[i].Total_Quantity
                });
            }

           
            return AllInvoices;
        }

        public async Task<InvoiceDetailsModel> GetInvoiceByID(int ID)
        {
            var Invoice = await _db.Invoices.FindAsync(ID);

            var InvoiceDetails = _db.Invoice_Details.Where(x => x.Invoice_ID == Invoice.Invoice_ID).ToList();

            var Item_Id = await _db.Invoice_Details.FirstOrDefaultAsync(a => a.Invoice_ID == Invoice.Invoice_ID);

            List<string> Items = new List<string>();
            List<double> UnitPrice = new List<double>();
            List<double> TPricePerTotalItems = new List<double>();
            List<int> TQuantityPerItem = new List<int>();
            

            foreach (var item in InvoiceDetails)
            {
               var ItemRow= _db.Items.FirstOrDefault(x=>x.Item_ID==item.Item_ID);
                Items.Add(ItemRow.Item_Name);
                UnitPrice.Add(ItemRow.Unit_Price);
                TPricePerTotalItems.Add(item.TPrice_PerTotalItems);
                TQuantityPerItem.Add(item.TQuantity_PerItem);
            }
            InvoiceDetailsModel InvoiceInfo = new InvoiceDetailsModel()
            {
                Invoice_ID = Invoice.Invoice_ID,
                Invoice_Date = Invoice.Invoice_Date,
                CX_Name = _db.Customers.Where(a => a.Customer_ID == Invoice.CX_ID).Select(a => a.FName).FirstOrDefault(),
                Item_Name = Items,
                Total_Price=Invoice.Total_Price,
                Total_Quantity=Invoice.Total_Quantity,
                TPrice_PerTotalItems= TPricePerTotalItems,
                 TQuantity_PerItem= TQuantityPerItem,
                 Unit_Price= UnitPrice

            };
            return InvoiceInfo;

        }

        public async Task<bool> DeleteInvoiceDetails(int ID) 
        {
            var Data = await _db.Invoice_Details.Where(x => x.Invoice_ID== ID).FirstOrDefaultAsync();
            if (Data == null)
                return false;
            else
            {
               var Invoice= await _db.Invoices.Where(x => x.Invoice_ID == ID).FirstOrDefaultAsync();
                _db.Invoices.Remove(Invoice);
                _db.Invoice_Details.Remove(Data);
                _db.SaveChanges();
                return true;
            }
        }
    }
}
