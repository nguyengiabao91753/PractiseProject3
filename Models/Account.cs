using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Account
{
    public int AccountId { get; set; }

    public string Password { get; set; } = null!;

    public int LevelId { get; set; }

    public virtual User AccountNavigation { get; set; } = null!;

    public virtual Level Level { get; set; } = null!;
}
