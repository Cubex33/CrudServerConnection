using System;
using System.Collections.Generic;

namespace CurlConnection.Models;

public partial class User : Entity
{
    

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool IsAdmin { get; set; }
}
