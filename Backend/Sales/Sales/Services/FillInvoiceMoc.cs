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
                
            };
            _db.Invoices.Add(NewInvoice);


            

            var DetailsInvoice = new Invoice_Details()
            {
                Invoice_ID = NewInvoice.Invoice_ID,
                TQuantity_PerItem=InvDet.TQuantity_PerItem,
                TPrice_PerTotalItems=InvDet.TPrice_PerTotalItems,
                
            };


            _db.Invoice_Details.Add(DetailsInvoice);
            _db.SaveChanges();
            return InvDet;
        }
    }
}
