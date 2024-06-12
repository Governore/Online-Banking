using System;
using System.Collections.Generic;

namespace OnlBank_b.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public int? RoleId { get; set; }

    public virtual ICollection<Admintransaction> Admintransactions { get; set; } = new List<Admintransaction>();

    public virtual Adminrole? Role { get; set; }
}
