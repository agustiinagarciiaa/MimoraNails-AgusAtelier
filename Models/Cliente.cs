using System;
using System.Collections.Generic;

namespace sistemaUñas_MimoraNails.Models;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string? Email { get; set; }

    public DateOnly FechaRegistro { get; set; }

    public string? Observaciones { get; set; }

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
