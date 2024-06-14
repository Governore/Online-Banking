using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? FailedLoginAttempts { get; set; }

    public bool? AccountLocked { get; set; }

    public string? PasswordResetToken { get; set; }

    public DateTime? PasswordResetExpiry { get; set; }

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<Helprequest> Helprequests { get; set; } = new List<Helprequest>();

    public virtual ICollection<Otp> Otps { get; set; } = new List<Otp>();

    public virtual ICollection<Request> Requests { get; set; } = new List<Request>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
