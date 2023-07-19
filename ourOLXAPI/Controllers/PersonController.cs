using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ourOLXAPI.Models;
using ourOLXAPI.Services.Interfaces;

namespace ourOLXAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IPersonService _personService;

        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        [HttpGet]
        [Route("getallpersons", Name = "GetAllPersons")]
        public IActionResult GetAllPersons([Required] string fileLocation)
        {

            var response = _personService.GetAllPersons(fileLocation);

            return Ok(response);

        }

        [HttpPost]
        [Route("createPerson", Name = "CreatePerson")]
        public IActionResult CreatePerson([FromBody] CreatePersonRequest request)
        {

            var response = _personService.CreateAllPersons(request);

            return Ok(response);

        }

        [HttpPost]
        [Route("updatePerson", Name = "UpdatePerson")]
        public IActionResult UpdateAllPersons([FromBody] FieldsToUpdate request)
        {

            var response = _personService.UpdateAllPersons(request);

            return Ok();

        }

        //[HttpPost]
        //[Route("deletePerson", Name = "DeletePerson")]
        //public IActionResult DeletePerson([FromBody] DeletePersonRequest request)
        //{

        //var response = _personService.DeleteAllPersons(request);

        //    return Ok();

        //}



    }
}
