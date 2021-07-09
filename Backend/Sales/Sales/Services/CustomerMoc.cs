using Sales.Models;
using Sales.Services.Interfaces;
using Sales.ViewModels;
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
        public async Task<CustomerssModel> Add(CustomerssModel Cx)
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
                

        }
}
