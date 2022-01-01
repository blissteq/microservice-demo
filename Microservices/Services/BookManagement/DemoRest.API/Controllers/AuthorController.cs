using DemoRest.Abstraction.Authors.Models;
using DemoRest.Abstraction.Authors.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService bookService)
        {
            _authorService = bookService;
        }

        [HttpGet]
        public async Task<IEnumerable<Author>> Get()
        {
            var result = await _authorService.GetAuthor();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Author> Get(int id)
        {
            return await _authorService.GetAuthor(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Author value)
        {
            var result = await _authorService.AddAuthor(value);
            if (result.Count < 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Author value)
        {
            var result = await _authorService.UpdateAuthor(value);
            if (result.Count < 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _authorService.DeleteAuthor(id);
            if (result.Count < 1)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
