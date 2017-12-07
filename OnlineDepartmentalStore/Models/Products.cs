using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace OnlineDepartmentalStore.Models
{
    public class Products
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Please Provide Customer Name")]
        [DisplayName("Customer Name")]
        public string CustomerName { get; set; }
        [Required(ErrorMessage="Please Provide Address")]
        public string Address{ get; set;}
        [Required(ErrorMessage="Please Provide Contact Number")]
        [DisplayName("Contact Number")]
        public string ContactNumber{get;set;}
        public string Rice { get; set; }
        public string Egg { get; set; }
        public string Milk { get; set; }
        public string Biscuit { get; set; }
        public string Chocolate { get; set; }
        public string IceCream { get; set; }
        public string Dal { get; set; }
        public string Sugar { get; set; }
        public string Oil { get; set; }
        public string Flour { get; set; }
        public string Total { get; set; }

    }
}