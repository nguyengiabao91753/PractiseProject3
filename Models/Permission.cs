using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class Permission
{
    public int PerId { get; set; }

    public int? ModuleId { get; set; }

    public string? Name { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<LevelHasPermission> LevelHasPermissions { get; set; } = new List<LevelHasPermission>();

    public virtual Module? Module { get; set; }
}
