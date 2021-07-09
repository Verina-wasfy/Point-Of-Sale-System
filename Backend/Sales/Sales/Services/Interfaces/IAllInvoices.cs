using Sales.Models;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Interfaces
{
    public interface IAllInvoices
    {
         Task<List<AllInvoicesModel>> GetAll();
        Task <InvoiceDetailsModel> GetInvoiceByID(int ID);
        Task<bool> DeleteInvoiceDetails(int ID);
    }
}
