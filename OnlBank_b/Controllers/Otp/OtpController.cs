using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlBank_b.Models;

namespace OnlBank_b.Controllers.Otp
{
    [ApiController]
    [Route("[controller]")]
    public class OtpController : ControllerBase
    {
        private readonly BankingonlineContext _context;
        public OtpController(BankingonlineContext context)
        {
            _context = context;
        }

        [HttpPost("generate")]
        public IActionResult GenerateOTP(int number)
        {
            string otpCode = generateRandomOtp(number); 
            DateTime expiryDate = DateTime.Now.AddMinutes(5);
            var otp = new Models.Otp
            {
                Otpcode = otpCode,
                ExpiryDate = expiryDate
            };
            _context.Otps.Add(otp);
            _context.SaveChanges();
            return Ok(new { otpCode, expiryDate });
        }

<<<<<<< Updated upstream
        private string generateRandomOtp(int number)
        {
            Random random = new Random();
            int min = (int)Math.Pow(10, number - 1);
            int max = (int)Math.Pow(10, number) - 1;

=======
        [HttpGet]
        public IActionResult GetOTP(string otpcode, int id)
        {
            // var code = _context.Otps.FirstOrDefault(e => e.UserId == id && e.Otpcode == otpcode);
            var code = _context.Otps.FirstOrDefault(e =>  e.Otpcode == otpcode);

            if (code == null)
            {
                return NotFound("OTP not found for the user");
            }

            var currentTime = DateTime.Now;
            var timeDifference = currentTime - code.ExpiryDate;
            if (timeDifference.TotalMinutes > 5)
            {
                return BadRequest("Mã OTP đã quá hạn, mời bạn gửi lại mã");
            }

            return Ok(code);
        }

        private string generateRandomOtp(int number)
        {
            Random random = new Random();
            int min = (int)Math.Pow(10, number - 1);
            int max = (int)Math.Pow(10, number) - 1;

>>>>>>> Stashed changes
            return random.Next(min, max).ToString();
        }
    }
}