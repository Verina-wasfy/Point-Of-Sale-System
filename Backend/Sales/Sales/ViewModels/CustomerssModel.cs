using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.ViewModels
{
    public class CustomerssModel
    {
        public int Customer_ID { set; get; }
        [Required]
        public string FName { set; get; }
        [Required]
        public string LName { set; get; }
        public string Address { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public DateTime Date_Of_Birth { set; get; }
        public int Phone_Num { set; get; }
       // public string Message { set; get; }
    }
}
