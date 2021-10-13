using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLocationAPI.Data.DataModels
{
    [Table("Venue")]
    public class Venue
    {
        [Key]
        public string id { get; set; }
        public string name { get; set; }
        public bool verified { get; set; }
        public string referralId { get; set; }
        public string address { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }
}
