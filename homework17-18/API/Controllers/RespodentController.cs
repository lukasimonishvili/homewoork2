using API.Services;
using API.Validators;
using DOMAIN;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("/api/[Controller]")]
    public class RespodentController : Controller
    {
        private readonly RespodentService _respodentService;
        private readonly AuthService _authService;
        public RespodentController(RespodentService respodentService, AuthService authService)
        {
            _respodentService = respodentService;
            _authService = authService;
        }

        [HttpGet("getAll")]
        public IActionResult FetchAllRespodents()
        {
            var respodents = _respodentService.FetchAllRespodents();
            return Ok(respodents);
        }


        [HttpGet("getById/{id}")]
        public IActionResult fetchRespodentByIdDto(int id)
        {
            var respodent = _respodentService.FetchRespodentById(id);

            if (respodent == null)
            {
                return NotFound($"respodent with Id: {id} not found in system");
            }

            return Ok(respodent);
        }

        [HttpGet("Filter")]
        public IActionResult FilterRespodents(string firstName, string lastName, string jobPosition, string salary, string workExperience)
        {
            var filteredList = _respodentService.FilterRespodents(firstName, lastName, jobPosition, salary, workExperience);
            return Ok(filteredList);
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteRespodentById(int id)
        {
            string authorizationHeader = HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length).Trim();
                var role = _authService.GetRoleFromToken(token);

                if (role != Roles.Admin)
                {
                    return Unauthorized("Permision denied");
                }
            }
            var respodent = _respodentService.FetchRespodentById(id);

            if (respodent == null)
            {
                return NotFound($"respodent with Id: {id} not found in system");
            }

            var updatedList = _respodentService.DeleteRespodent(respodent);
            return Ok(updatedList);
        }

        [HttpPut("update/{id}")]
        public IActionResult UpdateRespodent(RespodentAutheDTO respodent, int id)
        {
            string authorizationHeader = HttpContext.Request.Headers["Authorization"];
            if (!string.IsNullOrEmpty(authorizationHeader) && authorizationHeader.StartsWith("Bearer "))
            {
                string token = authorizationHeader.Substring("Bearer ".Length).Trim();
                var role = _authService.GetRoleFromToken(token);

                if (role != Roles.Admin)
                {
                    return Unauthorized("Permision denied");
                }
            }

            var validator = new RespodentValidator().Validate(respodent);
            var errorMessages = "";
            var respodentDB = _respodentService.FetchRespodentById(id);

            foreach (var error in validator.Errors)
            {
                errorMessages += error.ErrorMessage + ", ";
            }
            if (respodentDB == null)
            {
                return NotFound($"respodent with Id: {id} not found in system");
            }

            if (validator.IsValid)
            {
                var respodents = _respodentService.UpdateRespodent(respodentDB, respodent);
                return Ok(respodents);
            }
            else
            {
                return BadRequest(errorMessages);
            }
        }
    }
}
