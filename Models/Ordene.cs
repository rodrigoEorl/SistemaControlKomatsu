using System;
using System.Collections.Generic;

namespace SistemaControl.Models;

public partial class Ordene
{
    public string IdOrden { get; set; } = null!;

    public string? Detalle { get; set; }

    public int? Estado { get; set; }

    public int? Tipo { get; set; }

    public virtual ICollection<Interrupcione> Interrupciones { get; set; } = new List<Interrupcione>();
}
