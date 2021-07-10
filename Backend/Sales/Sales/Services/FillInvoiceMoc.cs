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
    public class FillInvoiceMoc : IInvoiceFill

    {
        private ApiDbContext _db;

        public FillInvoiceMoc(ApiDbContext db)
        {
            _db = db;

        }

        public async Task<InvoiceDetailsModel> Add(InvoiceDetailsModel InvDet)
        {

            int InvoiceId = _db.Invoices.ToList().Count() > 0 ? _db.Invoices.Max(x => x.Invoice_ID) + 1 : 1;
            var Cst = await _db.Customers.FirstOrDefaultAsync(a => a.FName == InvDet.CX_Name);

            var NewInvoice = new Invoice()
            {
                Invoice_ID= InvoiceId,
                Invoice_Date=DateTime.Now,
                CX_ID=Cst.Customer_ID,
                Total_Price=InvDet.Total_Price,
                Total_Quantity= InvDet.Total_Quantity

            };
            _db.Invoices.Add(NewInvoice);

            //List<string> Items = new List<string>();
            //List<double> UnitPrice = new List<double>();
            //List<double> TPricePerTotalItems = new List<double>();
            //List<int> TQuantityPerItem = new List<int>();
            //var DetailsInvoice = new Invoice_Details();
            var DetailsInvoice = new List<Invoice_Details>();

            for (int i = 0; i < InvDet.TPrice_PerTotalItems.Count; i++)
            {
                //Items[i] = InvDet.Item_Name[i];
                //UnitPrice[i] = InvDet.Unit_Price[i];
                //TPricePerTotalItems[i] = InvDet.TPrice_PerTotalItems[i];
                //TQuantityPerItem[i]= InvDet.TQuantity_PerItem[i];
                var ItemID = _db.Items.FirstOrDefault(x => x.Item_Name == InvDet.Item_Name[i]);
                DetailsInvoice.Add(new Invoice_Details()
                {
                    Invoice_ID = InvoiceId,
                    TPrice_PerTotalItems = InvDet.TPrice_PerTotalItems[i],
                    TQuantity_PerItem = InvDet.TQuantity_PerItem[i],
                    Item_ID = ItemID.Item_ID,
                    UnitPrice = InvDet.Unit_Price[i],

                }) ;
                 // _db.Invoice_Details.Add(DetailsInvoice[i]);

            }

            await _db.Invoice_Details.AddRangeAsync(DetailsInvoice);
            _db.SaveChanges();
            return InvDet;
        }

        public async Task<InvoiceDetailsModel> Edit(InvoiceDetailsModel ObjToEdit)
        {
            var Invoice = await _db.Invoices.FindAsync(ObjToEdit.Invoice_ID);
            var InvoiceDet = await _db.Invoice_Details.FindAsync(ObjToEdit.Invoice_ID);

            Invoice.Invoice_ID = ObjToEdit.Invoice_ID;
            Invoice.Invoice_Date = ObjToEdit.Invoice_Date;
            Invoice.CX_ID = ObjToEdit.CX_ID;
            Invoice.Total_Quantity = ObjToEdit.Total_Quantity;
            Invoice.Total_Price = ObjToEdit.Total_Price;
                         
            for (int i = 0; i < ObjToEdit.TPrice_PerTotalItems.Count; i++)
            {
               var ItemID = _db.Items.FirstOrDefault(x => x.Item_Name == ObjToEdit.Item_Name[i]);
              
                InvoiceDet.Invoice_ID = ObjToEdit.Invoice_ID;
                InvoiceDet.TPrice_PerTotalItems = ObjToEdit.TPrice_PerTotalItems[i];
                InvoiceDet.TQuantity_PerItem = ObjToEdit.TQuantity_PerItem[i];
                InvoiceDet.Item_ID = ItemID.Item_ID;
                InvoiceDet.UnitPrice = ObjToEdit.Unit_Price[i];

            }
           
            _db.SaveChanges();
            return ObjToEdit;
        }
    }
}
