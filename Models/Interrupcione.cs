using System;
using System.Collections.Generic;

namespace SistemaControl.Models;

public partial class Interrupcione
{
    public int IdInte { get; set; }

    public DateTime DiaIni { get; set; }

    public DateTime HoraIni { get; set; }

    public DateTime? DiaFin { get; set; }

    public DateTime? HoraFin { get; set; }

    public string? MotivoBase { get; set; }

    public string? Motivo { get; set; }

    public string IdOrden { get; set; } = null!;

    public virtual Ordene IdOrdenNavigation { get; set; } = null!;
}
