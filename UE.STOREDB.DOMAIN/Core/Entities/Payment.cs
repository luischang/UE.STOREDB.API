using System;
using System.Collections.Generic;

namespace UE.STOREDB.DOMAIN.Core.Entities;

public partial class Payment
{
    public int Id { get; set; }

    public int? OrdersId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Status { get; set; }

    public virtual Orders? Orders { get; set; }
}
