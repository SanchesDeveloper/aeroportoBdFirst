using System;
using System.Collections.Generic;

namespace Teste;

public partial class Voo
{
    public int IdVoo { get; set; }

    public int PartidaId { get; set; }

    public int DestinoId { get; set; }

    public DateTime? PrevistoPartida { get; set; }

    public DateTime? PrevistoChegada { get; set; }

    public DateTime? TempoPartida { get; set; }

    public DateTime? TempoChegada { get; set; }

    public int AeronaveId { get; set; }

    public virtual Aeronave Aeronave { get; set; } = null!;

    public virtual Aeroporto Destino { get; set; } = null!;

    public virtual Aeroporto Partida { get; set; } = null!;

    public virtual ICollection<Passagem> Passagems { get; set; } = new List<Passagem>();
}
