using System;
using System.Collections.Generic;

namespace DPA_Shopping.DOMAIN.Infrastructure.Data;

public partial class Payment
{
    public int Id { get; set; }

    public int? OrdersId { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? PaymentMethod { get; set; }

    public string? Status { get; set; }

    public virtual Orders? Orders { get; set; }
}
