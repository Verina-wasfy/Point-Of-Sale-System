using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.ViewModels
{
    public class CustomerDataModel
    {
        public int Customer_ID { set; get; }
        [Required]
        public string FName { set; get; }
        public int Phone_Num { set; get; }
       
    }
}
