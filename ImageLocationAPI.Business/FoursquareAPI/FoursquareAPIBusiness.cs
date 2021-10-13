using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ImageLocationAPI.Business.DbLogic;
using ImageLocationAPI.Models.Image;
using ImageLocationAPI.Models.Venue;
using ImageLocationAPI.Service;

namespace ImageLocationAPI.Business.FoursquareAPI
{
    public class FoursquareApiBusiness : IFoursquareApiBusiness
    {
        private static readonly HttpClient _client = new HttpClient();
        private readonly IDataBusiness repo;

        public FoursquareApiBusiness()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            repo = new DataBusiness();
        }

        public async Task<List<VenueModel>> GetVenues(string venue, int limit)
        {
            limit = SetMaximumRequestLimit(limit);
            var model = new List<VenueModel>();
            var uriBuilder = $"{AppSettings.apiBaseUrl}v2/venues/search?client_id={AppSettings.clientId}&client_secret={AppSettings.clientSecret}&v={AppSettings.apiVersion}&limit={limit}&near={venue}";
            var response = await _client.GetAsync(uriBuilder);
            if (response.IsSuccessStatusCode)
            {
                var venueResult = await response.Content.ReadFromJsonAsync<VenueResultModel>();
                if (venueResult == null) return model;
                model = venueResult.response.venues;
                repo.AddVenues(model);
            }
            else
            {
                Console.WriteLine($"Failed to get Venues. {DateTimeOffset.Now}");
            }
            return model;
        }
        
        public async Task<List<ImageModel>> GetVenueImages(string venueId, int limit)
        {
            limit = SetMaximumRequestLimit(limit);
            var model = new List<ImageModel>();
            var uriBuilder = $"{AppSettings.apiBaseUrl}v2/venues/{venueId}/photos?client_id={AppSettings.clientId}&client_secret={AppSettings.clientSecret}&v={AppSettings.apiVersion}&limit={limit}";
            var response = await _client.GetAsync(uriBuilder);
            if (response.IsSuccessStatusCode)
            {
                var venueResult = await response.Content.ReadFromJsonAsync<ImageResultModel>();
                if (venueResult == null)
                    return model;
                model = venueResult.response.photos.items;
                repo.AddImages(model, venueId);

            }
            else
            {
                Console.WriteLine($"Failed to get Images. {DateTimeOffset.Now}");
            }
            return model;
            //Use this method when API reaches 50 requests a day
            //return RandomImagesForTestData();
        }

        public async Task<ImageModel> GetImagesDetails(string imageId)
        {
            var model = new ImageModel();
            var uriBuilder = $"{AppSettings.apiBaseUrl}v2/photos/{imageId}?client_id={AppSettings.clientId}&client_secret={AppSettings.clientSecret}&v={AppSettings.apiVersion}";
            var response = await _client.GetAsync(uriBuilder);
            if (response.IsSuccessStatusCode)
            {
                var venueResult = await response.Content.ReadFromJsonAsync<ImageResultModel>();
                if (venueResult != null)
                    model = venueResult.response.photo;
            }
            else
            {
                Console.WriteLine($"Failed to get Image Details. {DateTimeOffset.Now}");
            }
            return model;
        }

        private static int SetMaximumRequestLimit(int limit)
        {
            if (limit > AppSettings.maximumRequestLimit)
                limit = AppSettings.maximumRequestLimit;
            return limit;
        }

        private List<ImageModel> RandomImagesForTestData()
        {
            var images = new List<ImageModel>
            {
                new ImageModel()
                {
                    id = "5a60a975dd70c57035aebcf5",
                    createdAt = 1516284277,
                    prefix = "https://fastly.4sqi.net/img/general/",
                    suffix = "/70216644_a1RAL31Bb8s4isPstEAgle3dD08du5DByfQXSqTHZTU.jpg",
                    width = 1440,
                    height = 1920
                },
                new ImageModel()
                {
                    id = "5c6ffe25e55d8b0039441006",
                    createdAt = 1550843429,
                    prefix = "https://fastly.4sqi.net/img/general/",
                    suffix = "/407299499_IStx-VXuhvtdXHCzfvFPoBh6BtqA6XKraCNwGzyf6So.jpg",
                    width = 1440,
                    height = 1920
                },
                new ImageModel()
                {
                    id = "4fa5501ee4b0548306c9959e",
                    createdAt = 1336234014,
                    prefix = "https://fastly.4sqi.net/img/general/",
                    suffix = "/v6DZ-qAO9yux0o6RQ-MUMpZE1g8c_Ml9ZC3-aZB7FpE.jpg",
                    width = 612,
                    height = 612
                },
            };
            return images;
        }

    }
}
