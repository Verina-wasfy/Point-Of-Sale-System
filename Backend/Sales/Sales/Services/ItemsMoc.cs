using Microsoft.EntityFrameworkCore;
using Sales.Services.Interfaces;
using Sales.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Services
{
    public class ItemsMoc:IItems
    {
        private ApiDbContext _db;

        public ItemsMoc(ApiDbContext db)
        {
            _db = db;

        }
        public async Task<List<ItemsModel>> GetAll()
        {
            var LoadAll = await _db.Items
                       .ToListAsync();

            var Len = _db.Items.Count();

            List<ItemsModel> AllItems = new List<ItemsModel>();

            for (int i = 0; i < Len; i++)
            {

                AllItems.Add(new ItemsModel()
                {
                   Item_Name=LoadAll[i].Item_Name,
                   Unit_Price=LoadAll[i].Unit_Price,
                   Item_ID=LoadAll[i].Item_ID
                });
            }
            return AllItems;
        }

        public async Task<int>  GetUnitPriceByID(string name)
        {
            var Item = await _db.Items.FirstOrDefaultAsync(x=>x.Item_Name==name);
            var UnitPrice =(int) Item.Unit_Price;
            return UnitPrice;

        }
    }
}
