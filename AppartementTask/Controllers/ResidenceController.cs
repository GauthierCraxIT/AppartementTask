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


        
    }
}
