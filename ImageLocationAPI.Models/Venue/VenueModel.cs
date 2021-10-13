using System.Collections.Generic;
using ImageLocationAPI.Models.Image;

namespace ImageLocationAPI.Models.Venue
{
    public class VenueModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public VenueLocationModel location { get; set; }
        public List<venueCategoriesModel> categories { get; set; }
        public bool verified { get; set; }
        public string referralId { get; set; }
        public List<ImageModel> images { get; set; }
    }

    public class VenueLocationModel
    {
        public string address { get; set; }
        public decimal lat { get; set; }
        public decimal lng { get; set; }
        public string postalCode { get; set; }
        public string cc { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
    }

    public class venueCategoriesModel
    {
        public string id { get; set; }
        public string name { get; set; }
        public string pluralName { get; set; }
        public string shortName { get; set; }
        public bool primary { get; set; }
    }
}
