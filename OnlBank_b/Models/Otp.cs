﻿using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Otp
{
    public int Otpid { get; set; }

    public int? UserId { get; set; }

    public string Otpcode { get; set; } = null!;

<<<<<<< HEAD
    public DateTime ExpiryDate { get; set; }
=======
    public DateTime CreateTime { get; set; } 
>>>>>>> TieuBao

    public virtual User? User { get; set; }
}
