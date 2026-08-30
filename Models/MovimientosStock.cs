using System;
using System.Collections.Generic;

namespace sistemaUñas_MimoraNails.Models;

public partial class MovimientosStock
{
    public int IdMstock { get; set; }

    public string TipoMovimiento { get; set; } = null!;

    public int Cantidad { get; set; }

    public DateOnly FechaMovimiento { get; set; }

    public int IdProducto { get; set; }

    public virtual Producto IdProductoNavigation { get; set; } = null!;
}
