using System;
using System.Collections.Generic;

namespace sistemaUñas_MimoraNails.Models;

public partial class Servicio
{
    public int IdServicio { get; set; }

    public string NombreServicio { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int Duracion { get; set; }

    public virtual ICollection<Turno> Turnos { get; set; } = new List<Turno>();
}
