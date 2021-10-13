using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageLocationAPI.Business.FoursquareAPI;
using ImageLocationAPI.Models.Image;
using ImageLocationAPI.Models.Venue;
using ImageLocationAPI.Service;
using Microsoft.AspNetCore.Cors;

namespace ImageLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ImageLocation")]
    public class VenueController : ControllerBase
    {
        private readonly IFoursquareApiBusiness _apiBusiness;

        public VenueController()
        {
            _apiBusiness = new FoursquareApiBusiness();
        }

        [HttpGet]
        public async Task<List<VenueModel>> Get(string venue, int limit = AppSettings.responseLimit)
        {
            var result = await _apiBusiness.GetVenues(venue, limit);
            return result;
        }

        [HttpGet]
        [Route("Images/{id}")]
        public async Task<List<ImageModel>> GetVenueImages(string id, int limit = AppSettings.responseLimit)
        {
            var result = await _apiBusiness.GetVenueImages(id, limit);
            return result;
        }
    }
}
