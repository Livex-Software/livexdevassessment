using System;
using System.Collections.Generic;

namespace LivexDevTechnicalAssessment.Entities.Models;

public partial class CustomerInventory
{
    public Guid CustomerInventoryId { get; set; }

    public Guid InventoryId { get; set; }

    public int Quantity { get; set; }

    public Guid CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Inventory Inventory { get; set; } = null!;
}
