using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.ViewModels
{
    public class AllInvoicesModel
    {
        public int Invoice_ID { set; get; }
        public DateTime Invoice_Date { set; get; }
        public int CX_ID { set; get; }
        public string CX_Name { set; get; }
        public double Total_Price { set; get; }
        public int Total_Quantity { set; get; }
    }
}
