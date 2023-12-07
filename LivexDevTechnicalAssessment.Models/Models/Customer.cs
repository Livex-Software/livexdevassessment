using System;
using System.Collections.Generic;

namespace LivexDevTechnicalAssessment.Entities.Models;

public partial class Customer
{
    public Guid CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string EmailAddress { get; set; } = null!;

    public virtual ICollection<CustomerInventory> CustomerInventories { get; set; } = new List<CustomerInventory>();
}
