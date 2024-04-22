using System;
using System.Collections.Generic;

namespace SistemaControl.Models;

public partial class Maestro
{
    public int IdMaestro { get; set; }

    public string? Codigo { get; set; }

    public int? Valor { get; set; }

    public string? Texto { get; set; }
}
