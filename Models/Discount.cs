using System;
using System.Collections.Generic;

namespace CurlConnection.Models;

public partial class Discount : Entity
{
    

    public int? CustomerId { get; set; }

    public int? Discount1 { get; set; }

    public int? Activation { get; set; }
}
