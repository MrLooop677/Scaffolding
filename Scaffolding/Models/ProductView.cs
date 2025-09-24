using System;
using System.Collections.Generic;

namespace Scaffolding.Models;

public partial class ProductView
{
    public string ProductName { get; set; } = null!;

    public string BrandName { get; set; } = null!;

    public decimal ListPrice { get; set; }
}
