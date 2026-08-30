using System;
using System.Collections.Generic;

namespace sistemaUñas_MimoraNails.Models;

public partial class Producto
{
    public int IdProducto { get; set; }

    public string NombreProducto { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public int StockActual { get; set; }

    public virtual ICollection<MovimientosStock> MovimientosStocks { get; set; } = new List<MovimientosStock>();
}
