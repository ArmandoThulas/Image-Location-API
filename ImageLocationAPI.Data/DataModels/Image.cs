using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLocationAPI.Data.DataModels
{
    [Table("Image")]
    public class Image
    {
        [Key]
        public string id { get; set; }
        public int createdAt { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string prefix { get; set; }
        public string suffix { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public string visibility { get; set; }
        public string type { get; set; }
        public int timeZoneOffset { get; set; }
        [ForeignKey("Venue")]
        public string venueId { get; set; }
        public virtual Venue Venue { get; set; }
    }
}
