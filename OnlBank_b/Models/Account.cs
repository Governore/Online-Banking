using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public int? UserId { get; set; }

    public string AccountNumber { get; set; } = null!;

    public decimal? Balance { get; set; }

    public virtual ICollection<Admintransaction> Admintransactions { get; set; } = new List<Admintransaction>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual ICollection<Transfertransaction> TransfertransactionFromAccounts { get; set; } = new List<Transfertransaction>();

    public virtual ICollection<Transfertransaction> TransfertransactionToAccounts { get; set; } = new List<Transfertransaction>();

    public virtual User? User { get; set; }
}
