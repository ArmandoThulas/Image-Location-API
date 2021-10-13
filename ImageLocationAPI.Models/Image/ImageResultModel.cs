using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLocationAPI.Models.Image
{
    public class ImageResultModel
    {
        public Response response { get; set; }
    }

    public class Response
    {
        public Photo photos { get; set; }
        public ImageModel photo { get; set; }
    }

    public class Photo
    {
        public int count { get; set; }
        public List<ImageModel> items { get; set; }
    }
}
