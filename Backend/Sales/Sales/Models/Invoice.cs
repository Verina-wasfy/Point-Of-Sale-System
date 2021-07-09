using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Invoice_ID { set; get; }
        public DateTime Invoice_Date { set; get; }
        [ForeignKey("Customer")]
        public int CX_ID { set; get; }
        public double Total_Price { set; get; }
        public int Total_Quantity { set; get; }
        public Customer Customer { set; get; }
        public List<Item> Items { set; get; }

    }
}
