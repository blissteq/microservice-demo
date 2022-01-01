using DemoRestTest.Abstraction.BookReader.Model;
using DemoRestTest.Abstraction.BookReader.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRestTest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReaderController : ControllerBase
    {
        private readonly IReaderApplication _readerService;

        public ReaderController(IReaderApplication readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public async Task<IEnumerable<Reader>> Get()
        {
            var result = await _readerService.GetReaders();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Reader> Get(int id)
        {
            return await _readerService.GetReader(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Reader value)
        {
            var result = await _readerService.AddReader(value);
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
        public async Task<IActionResult> Put([FromBody] Reader value)
        {
            var result = await _readerService.UpdateReader(value);
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
            var result = await _readerService.DeleteReader(id);
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
