using System.Collections.Generic;
using System.Threading.Tasks;
using ImageLocationAPI.Models.Image;
using ImageLocationAPI.Models.Venue;

namespace ImageLocationAPI.Business.DbLogic
{
    public interface IDataBusiness
    {
        Task AddVenues(List<VenueModel> venues);
        Task AddImages(List<ImageModel> images, string venueId);
    }
}