using System;
using System.Collections.Generic;

namespace Scaffolding.Models;

public partial class Log
{
    public int LogId { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedAt { get; set; }
}
