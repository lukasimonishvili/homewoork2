using homework14.Models;
using homework14.services;
using homework14.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace homework14.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RespodentController : Controller
    {
        private readonly RespodentService _respodentService;
        public RespodentController(RespodentService respodentService)
        {
            _respodentService = respodentService;
        }

        [HttpPost("add")]
        public IActionResult AddRespodent(Respodent respodent)
        {
            var validator = new RespodentValidator().Validate(respodent);
            var errorMessages = "";
            foreach (var error in validator.Errors)
            {
                errorMessages += error.ErrorMessage + ", ";
            }

            if (validator.IsValid)
            {
                var respodents = _respodentService.CreateNewRespodent(respodent);
                return Ok(respodents);
            }
            else
            {
                return BadRequest(errorMessages);
            }
        }

        [HttpGet("all")]
        public IActionResult GetAllRespodents()
        {
            var respodents = _respodentService.GetAllRespodents();
            return Ok(respodents);
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetRespodentById(string id)
        {
            var respodent = _respodentService.GetRespodentById(id);
            if (respodent == null)
            {
                return NotFound($"respodent with Id: {id} not found in system");
            }
            return Ok(respodent);
        }

        [HttpGet("Filter")]
        public IActionResult FilterRespodents(string firstName, string lastName, string jobPosition, string salary, string workExperience)
        {
            List<Respodent> filteredList = _respodentService.FilterRespodents(firstName, lastName, jobPosition, salary, workExperience);
            return Ok(filteredList);
        }

        [HttpPut("Update/{id}")]
        public IActionResult UpdateRespodent(Respodent respodent, string id)
        {
            var validator = new RespodentValidator().Validate(respodent);
            var errorMessages = "";
            var index = _respodentService.FindIndexById(id);
            foreach (var error in validator.Errors)
            {
                errorMessages += error.ErrorMessage + ", ";
            }
            if (index == -1)
            {
                return NotFound($"respodent with Id: {id} not found in system");
            }

            if (validator.IsValid)
            {
                var respodents = _respodentService.UpdateRespodent(respodent, id);
                return Ok(respodents);
            }
            else
            {
                return BadRequest(errorMessages);
            }
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult DeleteRespodent(string id)
        {
            var index = _respodentService.FindIndexById(id);

            if (index == -1)
            {
                return NotFound($"respodent with Id: {id} not found in system");
            }

            var respodents = _respodentService.DeleteRespodent(id);
            return Ok(respodents);
        }

    }
}
