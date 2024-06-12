using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Helprequest
{
    public int HelpRequestId { get; set; }

    public int? UserId { get; set; }

    public string? HelpRequestContent { get; set; }

    public DateTime? RequestDate { get; set; }

    public virtual User? User { get; set; }
}
