using Sales.Models;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Interfaces
{
    public interface ICustomer
    {
        Task<CustomerDataModel> Add(CustomerDataModel Cx);
        Task<List<CustomerDataModel>> GetAll();
    }
}
