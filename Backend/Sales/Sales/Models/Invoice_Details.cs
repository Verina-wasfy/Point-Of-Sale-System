using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Invoice_Details
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Item")]
        public int Item_ID { get; set; }
        [Key]
        [Column(Order = 1)]
        [ForeignKey("Invoice")]
        public int Invoice_ID{ get; set; }
        public double TPrice_PerTotalItems{ set; get; }
        public int TQuantity_PerItem { set; get; }
    }
}
