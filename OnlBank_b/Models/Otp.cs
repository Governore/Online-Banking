using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Otp
{
    public int Otpid { get; set; }

    public int? UserId { get; set; }

    public string Otpcode { get; set; } = null!;

    public DateTime ExpiryDate { get; set; }

    public virtual User? User { get; set; }
}
