using LivexDevTechnicalAssessment.Entities.Models;
using System;
using System.Collections.Generic;

namespace LivexDevTechnicalAssessment.Entities.ViewModels;

public partial class CheckoutModel
{
    public Inventory? Inventories { get; set; }
    public Guid? CustomerId { get; set; }
}