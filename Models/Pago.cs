using System;
using System.Collections.Generic;

namespace sistemaUñas_MimoraNails.Models;

public partial class Pago
{
    public int IdPago { get; set; }

    public decimal Monto { get; set; }

    public DateOnly FechaPago { get; set; }

    public string MetodoPago { get; set; } = null!;

    public decimal SaldoPendiente { get; set; }

    public int IdTurno { get; set; }

    public virtual Turno IdTurnoNavigation { get; set; } = null!;
}
