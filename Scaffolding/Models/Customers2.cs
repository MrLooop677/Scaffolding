using System;
using System.Collections.Generic;

namespace Scaffolding.Models;

public partial class Customers2
{
    public int CustomerId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
