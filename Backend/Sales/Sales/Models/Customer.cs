using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Sales.Models
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Customer_ID {set; get;}
        [Required]
        [MinLength(3, ErrorMessage = "Name length can't be less than 3 letters.")]
        public string FName {set; get;}
        //[EmailAddress]
        //[RegularExpression(@"[a-z A-Z 0-9_]*@[a-z A-Z]+.[a-z A-Z]{2,4}", ErrorMessage = "Invalid Email.")]
        //public string Email {get; set;}
        //[DataType(DataType.Date)]
        //public DateTime Date_Of_Birth {set; get;}
        [Phone]
        [RegularExpression(@"^([0-9]{10})$", ErrorMessage = "Invalid Mobile Number.")]
        public int Phone_Num { set; get; }
        public List<Invoice> Invoices { get; set; }

    }
}
