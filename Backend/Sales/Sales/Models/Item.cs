using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Item_ID {set; get;}
        [Required]
        public string Item_Name { set; get; }
        public int Quantity { set; get; }
        public bool Stock { set; get; }
        public double Unit_Price { set; get; }
        [DataType(DataType.Date)]
        public DateTime Production_Date { set; get; }
        public List<Invoice> Invoices { set; get; }
        

    }
}
