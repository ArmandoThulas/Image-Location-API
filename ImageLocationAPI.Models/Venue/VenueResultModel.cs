using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLocationAPI.Models.Venue
{
    public class VenueResultModel
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public List<VenueModel> venues { get; set; }
    }
}
