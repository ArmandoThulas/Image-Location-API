using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ImageLocationAPI.Business.FoursquareAPI;
using ImageLocationAPI.Models.Image;
using Microsoft.AspNetCore.Cors;

namespace ImageLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("ImageLocation")]
    public class ImageController : ControllerBase
    {
        private readonly IFoursquareApiBusiness _apiBusiness;

        public ImageController()
        {
            _apiBusiness = new FoursquareApiBusiness();
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<ImageModel> Get(string id)
        {
            var result = await _apiBusiness.GetImagesDetails(id);
            return result;
        }
    }
}
