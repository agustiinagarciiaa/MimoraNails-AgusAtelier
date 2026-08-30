using System;
using System.Collections.Generic;

namespace sistemaUñas_MimoraNails.Models;

public partial class Turno
{
    public int IdTurno { get; set; }

    public DateOnly FechaTurno { get; set; }

    public TimeOnly HoraTurno { get; set; }

    public string Estado { get; set; } = null!;

    public int IdCliente { get; set; }

    public int IdServicio { get; set; }

    public virtual Cliente IdClienteNavigation { get; set; } = null!;

    public virtual Servicio IdServicioNavigation { get; set; } = null!;

    public virtual ICollection<Pago> Pagos { get; set; } = new List<Pago>();
}
