using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLocationAPI.Data.DataModels
{
    [Table("VenueCategory")]
    public class VenueCategory
    {
        [Key]
        public Guid id { get; set; }
        [ForeignKey("Venue")]
        public string venueId { get; set; }

        public virtual Venue Venue { get; set; }
        [ForeignKey("Category")]
        public string categoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
