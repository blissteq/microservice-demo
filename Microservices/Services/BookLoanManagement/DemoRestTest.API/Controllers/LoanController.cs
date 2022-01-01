using DemoRestTest.Abstraction.BookLoan.Model;
using DemoRestTest.Abstraction.BookLoan.Service;
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
    public class LoanController : ControllerBase
    {
        private readonly ILoanApplication _loanService;

        public LoanController(ILoanApplication loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public async Task<IEnumerable<Loan>> Get()
        {
            var result = await _loanService.GetLoans();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<Loan> Get(int id)
        {
            return await _loanService.GetLoan(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Loan value)
        {
            var result = await _loanService.AddLoan(value);
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
        public async Task<IActionResult> Put([FromBody] Loan value)
        {
            var result = await _loanService.UpdateLoan(value);
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
            var result = await _loanService.DeleteLoan(id);
            return Ok(result);
        }
    }
}
