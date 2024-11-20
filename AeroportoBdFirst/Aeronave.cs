using System;
using System.Collections.Generic;

namespace Teste;

public partial class Aeronave
{
    public int IdAeronave { get; set; }

    public string? NomeAeronave { get; set; }

    public bool? Ativo { get; set; }

    public int ModeloAeronaveId { get; set; }

    public int? PilotoId { get; set; }

    public virtual ModeloAeronave ModeloAeronave { get; set; } = null!;

    public virtual Piloto? Piloto { get; set; }

    public virtual ICollection<Voo> Voos { get; set; } = new List<Voo>();
}
