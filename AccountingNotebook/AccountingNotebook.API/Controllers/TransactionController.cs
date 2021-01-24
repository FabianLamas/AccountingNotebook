using System;
using System.Threading.Tasks;
using AccountingNotebook.Data.Models;
using AccountingNotebook.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AccountingNotebook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetTransactionsAsync()
        {
            try
            {
                var result = await _transactionService.GetTransactionsAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionByIdAsync(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }

                var result = await _transactionService.GetTransactionByIdAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionAsync([FromBody] AccountTransaction model)
        {
            try
            {
                if (model?.Type == null)
                {
                    return BadRequest();
                }

                var result = await _transactionService.AddTransactionAsync(model);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
