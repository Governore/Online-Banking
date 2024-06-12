using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public int? AccountId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? TransactionType { get; set; }

    public virtual Account? Account { get; set; }
}
