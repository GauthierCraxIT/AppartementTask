using AppartementTask.DAO;
using AppartementTask.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppartementTask.Controllers
{
    [Route("api/residence")]
    [ApiController]
    public class ResidenceController : ControllerBase
    {

        public ResidenceService residenceService { get; set; }

        public ResidenceController(ResidenceService residenceService)
        {
            this.residenceService = residenceService;
        }


        [HttpPost]
        public IActionResult CreateResidence(ResidenceDto residenceDto)
        {
            if (ModelState.IsValid)
            {
                this.residenceService.CreateResidence(residenceDto);
                return Created("api/residence", residenceDto);
            }

            
            return BadRequest();
        }

        [HttpGet]
        public IActionResult GetResidences()
        {
            return new JsonResult(this.residenceService.GetResidences());
        }

        [HttpPut]
        public IActionResult UpdateResidence(ResidenceDto residenceDto)
        {
            if (ModelState.IsValid)
            {
                this.residenceService.UpdateResidence(residenceDto);
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete]
        public IActionResult DeleteResidence(ResidenceDto residenceDto)
        {
            if (ModelState.IsValid)
            {
                this.residenceService.DeleteResidence(residenceDto);
                return Ok();
            }

            return BadRequest();
        }



    }
}
