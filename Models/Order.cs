using System;
using System.Collections.Generic;

namespace CurlConnection.Models;

public partial class Order : Entity
{
    

    public int CustomerId { get; set; }

    public int EmployeeId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Employee Employee { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
