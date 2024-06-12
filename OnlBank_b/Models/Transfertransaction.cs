using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Transfertransaction
{
    public int TransferId { get; set; }

    public int? FromAccountId { get; set; }

    public int? ToAccountId { get; set; }

    public decimal? Amount { get; set; }

    public DateTime? TransferDate { get; set; }

    public string? Status { get; set; }

    public virtual Account? FromAccount { get; set; }

    public virtual Account? ToAccount { get; set; }
}
