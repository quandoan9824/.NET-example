using Hahn.ApplicatonProcess.December2020.Data;
using Hahn.ApplicatonProcess.December2020.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Main controller for handling requests
/// Created by DVQUAN 2.1.2020
/// </summary>
namespace Hahn.ApplicatonProcess.December2020.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class MainController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //   "Hi"
        //};

        private readonly ILogger<MainController> _logger;
        private MainContext _context;
        

        public MainController(MainContext context, ILogger<MainController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> SaveAppicant([FromBody]Applicant applicant)
        {
            var res = new ServiceResponse();
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            
            res.OnSuccessSave(Converter.GenApplicantId(applicant));
            try
            {
                await _context.Applicant.AddAsync(applicant);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetApplicant), new { id = applicant.ID }, applicant);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetApplicant(string? id)
        {
            var res = new ServiceResponse();
            var applicant = _context.Applicant.FirstOrDefault(a => a.ID == id);
            if (applicant != null)
            {
                res.OnSuccessGet(applicant);
                return Ok(res);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromBody]Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem();
            }
            try
            {
                _context.Applicant.Update(applicant);
                _context.SaveChangesAsync();
                return Ok(applicant);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(string? id, bool? saveChangesError = false)
        {
            var applicant = await _context.Applicant.FindAsync(id);
            if (applicant == null)
            {
                return NotFound();
            }

            try
            {
                _context.Applicant.Remove(applicant);
                await _context.SaveChangesAsync();
                return Ok(applicant);
            }
            catch (Exception /* ex */)
            {
                return NotFound();
            }
        }
    }
}
