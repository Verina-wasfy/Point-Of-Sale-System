using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services.Interfaces
{
    public interface IItems
    {
        Task<List<ItemsModel>> GetAll();
        Task<int> GetUnitPriceByID(int ID);
    }
}
