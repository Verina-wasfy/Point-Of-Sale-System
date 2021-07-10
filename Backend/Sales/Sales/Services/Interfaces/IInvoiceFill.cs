using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Interfaces
{
    public interface IInvoiceFill
    {
        Task<InvoiceDetailsModel> Add(InvoiceDetailsModel InvDet);
        Task<InvoiceDetailsModel> Edit(InvoiceDetailsModel ObjToEdit);
    }
}
