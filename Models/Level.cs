using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Level
{
    public int LevelId { get; set; }

    public string LevelName { get; set; } = null!;

    public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();

    public virtual ICollection<LevelHasPermission> LevelHasPermissions { get; set; } = new List<LevelHasPermission>();
}
