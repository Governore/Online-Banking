﻿using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Admintransaction
{
    public int AdminTransactionId { get; set; }

    public int? AdminId { get; set; }

    public int? UserId { get; set; }

    public int? AccountId { get; set; }

    public string? TransactionType { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TransactionDate { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Admin? Admin { get; set; }

    public virtual User? User { get; set; }
}
