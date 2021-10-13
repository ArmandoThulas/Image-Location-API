using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageLocationAPI.Business.AutoMapper;
using ImageLocationAPI.Data;
using ImageLocationAPI.Data.DataModels;
using ImageLocationAPI.Models.Image;
using ImageLocationAPI.Models.Venue;
using Microsoft.EntityFrameworkCore;

namespace ImageLocationAPI.Business.DbLogic
{
    public class DataBusiness : IDataBusiness
    {
        private readonly DataContext context;

        public DataBusiness()
        {
            context = new DataContext();
        }

        public async Task AddVenues(List<VenueModel> venues)
        {
            foreach (var venue in venues)
            {
                var dbModel = PopulateDataModel(venue);
                if (await AddVenue(dbModel)) continue;
                await AddCategories(venue);
            }
        }

        private static Venue PopulateDataModel(VenueModel venue)
        {
            var dbModel = MappingProfile.Mapper.Map<Venue>(venue);
            dbModel.address = venue.location.address;
            dbModel.lat = venue.location.lat;
            dbModel.lng = venue.location.lng;
            dbModel.postalCode = venue.location.postalCode;
            dbModel.cc = venue.location.cc;
            dbModel.city = venue.location.city;
            dbModel.state = venue.location.state;
            dbModel.country = venue.location.country;
            return dbModel;
        }

        private async Task<bool> AddVenue(Venue dbModel)
        {
            var venueFromDb = await context.Venues.FindAsync(dbModel.id);
            if (venueFromDb != null)
                return true;
            await context.Venues.AddAsync(dbModel);
            await context.SaveChangesAsync();
            return false;
        }

        private async Task AddCategories(VenueModel venue)
        {
            foreach (var category in venue.categories.Select(categoryModel => MappingProfile.Mapper.Map<Category>(categoryModel)))
            {
                var categoryFromDb = await context.Categories.FindAsync(category.id);
                if (categoryFromDb != null) continue;
                await context.Categories.AddAsync(category);
                await context.VenueCategories.AddAsync(new VenueCategory {categoryId = category.id, venueId = venue.id});
                await context.SaveChangesAsync();
            }
        }

        public async Task AddImages(List<ImageModel> images, string venueId)
        {
            foreach (var image in images)
            {
                var dbModel = PopulateImageData(image, venueId);
                await AddImage(dbModel);
            }
        }

        private static Image PopulateImageData(ImageModel image, string venueId)
        {
            var dbModel = MappingProfile.Mapper.Map<Image>(image);
            dbModel.name = image.source.name;
            dbModel.url = image.source.url;
            dbModel.venueId = venueId;
            dbModel.type = image.checkin.type;
            dbModel.timeZoneOffset = image.checkin.timeZoneOffset;
            return dbModel;
        }

        private async Task AddImage(Image dbModel)
        {
            var imageFromDb = await context.Images.FindAsync(dbModel.id);
            if (imageFromDb != null)
                return;
            await context.Images.AddAsync(dbModel);
            await context.SaveChangesAsync();
        }
    }
}
