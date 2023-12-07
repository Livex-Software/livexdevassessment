using System;
using System.Collections.Generic;

namespace LivexDevTechnicalAssessment.Entities.Models;

public partial class Inventory
{
    public Guid InventoryId { get; set; }

    public string InventoryName { get; set; } = null!;

    public string Sku { get; set; } = null!;

    public virtual ICollection<CustomerInventory> CustomerInventories { get; set; } = new List<CustomerInventory>();
}
