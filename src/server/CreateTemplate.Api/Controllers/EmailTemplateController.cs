using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CreateTemplate.Business.Models;
using CreateTemplate.Business.Services.Interfaces;
using CreateTemplate.Core.Results.Gird;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CreateTemplate.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class EmailTemplateController : ApiController
    {
      private IEmailTemplatesService _emailTemplatesService;

      public EmailTemplateController(IEmailTemplatesService emailTemplatesService)
      {
        _emailTemplatesService = emailTemplatesService;
      }

    // GET: api/<controller>
    /// <summary>
    /// get all email template
    /// </summary>
    /// <param name="gridModel"></param>
    /// <returns></returns>
    ///   /// <response code="200">The model was bound successfully.</response>
    /// <response code="401">Unauthorized</response>
    [HttpGet]
        public IActionResult Search(GridModel gridModel)
        {
          var lstEmail = _emailTemplatesService.Search(gridModel);
          return Ok(lstEmail);
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult>Post([FromBody]EmailTemplateModel model)
        {
          if (!ModelState.IsValid)
            return BadRequest(ModelState);
          var created = await _emailTemplatesService.Create(model);
          return Ok(created);
    }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody]EmailTemplateModel model)
        {
          if (!ModelState.IsValid)
            return BadRequest(ModelState);
          var update = await  _emailTemplatesService.Update(model, id);
          return Ok(update);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
