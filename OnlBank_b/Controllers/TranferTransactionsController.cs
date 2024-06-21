using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlBank_b.Models;
using OnlBank_b.Services;

namespace OnlBank_b.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly BankingonlineContext _context;
        private readonly OtpService _otpService;

        public TransactionController(BankingonlineContext context, OtpService otpService)
        {
            _context = context;
            _otpService = otpService;
        }

        // GET: api/Transaction/fromAccountInfo/5
        [HttpGet("fromAccountInfo/{id}")]
        public async Task<ActionResult<Account>> GetFromAccountInfo(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        // POST: api/Transaction/toAccountInfo
        [HttpPost("toAccountInfo")]
        public async Task<ActionResult<Transfertransaction>> PostToAccountInfo(Transfertransaction transfertransaction)
        {
            _context.Transfertransactions.Add(transfertransaction);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTransfertransaction", new { id = transfertransaction.TransferId }, transfertransaction);
        }

        // PUT: api/Transaction/updateBalance/5
        [HttpPut("updateBalance/{id}")]
        public async Task<IActionResult> UpdateBalance(int id, [FromBody] decimal amount)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            account.Balance += amount;
            _context.Entry(account).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Transaction/initiateTransaction
        [HttpPost("initiateTransaction")]
        public async Task<IActionResult> InitiateTransaction(int fromAccountId, int toAccountId, decimal amount, string userEmail)
        {
            var transferTransaction = new Transfertransaction
            {
                FromAccountId = fromAccountId,
                ToAccountId = toAccountId,
                Amount = amount,
                TransferDate = DateTime.Now,
                Status = "Pending"
            };

            _context.Transfertransactions.Add(transferTransaction);
            await _context.SaveChangesAsync();

            var result = await _otpService.GenerateAndSendOtp(6, userEmail);
            return result;
        }

        // POST: api/Transaction/verifyOtp
        [HttpPost("verifyOtp")]
        public async Task<IActionResult> VerifyOtp(string otp, int fromAccountId, int toAccountId, decimal amount)
        {
            var result = await _otpService.CheckOtp(otp, 0); 

            if (result is OkObjectResult)
            {
                var fromAccount = await _context.Accounts.FindAsync(fromAccountId);
                var toAccount = await _context.Accounts.FindAsync(toAccountId);

                if (fromAccount == null || toAccount == null)
                {
                    return NotFound();
                }

                fromAccount.Balance -= amount;
                toAccount.Balance += amount;

                _context.Entry(fromAccount).State = EntityState.Modified;
                _context.Entry(toAccount).State = EntityState.Modified;

                var transferTransaction = await _context.Transfertransactions.FirstOrDefaultAsync(t => t.FromAccountId == fromAccountId && t.ToAccountId == toAccountId && t.Status == "Pending");
                if (transferTransaction != null)
                {
                    transferTransaction.Status = "Completed";
                    _context.Entry(transferTransaction).State = EntityState.Modified;
                }

                await _context.SaveChangesAsync();

                return Ok(new { message = "Transaction completed successfully!" });
            }
            return result;
        }
    }
}
