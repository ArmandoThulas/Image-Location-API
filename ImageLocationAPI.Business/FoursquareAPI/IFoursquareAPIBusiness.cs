using System.Collections.Generic;
using System.Threading.Tasks;
using ImageLocationAPI.Models.Image;
using ImageLocationAPI.Models.Venue;

namespace ImageLocationAPI.Business.FoursquareAPI
{
    public interface IFoursquareApiBusiness
    {
        Task<List<VenueModel>> GetVenues(string venue, int limit);
        Task<List<ImageModel>> GetVenueImages(string venueId, int limit);
        Task<ImageModel> GetImagesDetails(string imageId);
    }
}