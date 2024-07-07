using System;
using System.Collections.Generic;

namespace WebApplicationBYD.Models;

public partial class LevelHasPermission
{
    public int Id { get; set; }

    public int? LevelId { get; set; }

    public int? PerId { get; set; }

    public virtual Level? Level { get; set; }

    public virtual Permission? Per { get; set; }
}
