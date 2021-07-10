using Microsoft.EntityFrameworkCore;
using Sales.Models;
using Sales.Services.Interfaces;
using Sales.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Sales.Services
{
    public class CustomerMoc:ICustomer
    {
        private ApiDbContext _db;
      
        public CustomerMoc(ApiDbContext db)
        {
            _db = db;
           
        }
        public async Task<CustomerDataModel> Add(CustomerDataModel Cx)
        {
           var NewCst = new Customer()
           {
             
                FName = Cx.FName,
                LName = Cx.LName,
                Email = Cx.Email,
                Date_Of_Birth = Cx.Date_Of_Birth,
                Gender = Cx.Gender,
                Phone_Num = Cx.Phone_Num,
                Address = Cx.Address

            };
            _db.Customers.Add(NewCst);
            _db.SaveChanges();
            return Cx;
        }

        public async Task<List<CustomerDataModel>> GetAll()
        {
            var LoadAll = await _db.Customers
                          .ToListAsync();

            var Len = _db.Customers.Count();

            List<CustomerDataModel> AllCst = new List<CustomerDataModel>();

            for (int i = 0; i < Len; i++)
            {

                AllCst.Add(new CustomerDataModel()
                {
                    FName=LoadAll[i].FName,
                    Phone_Num= LoadAll[i].Phone_Num
                  
                });
            }


            return AllCst;
        }
        }
}
