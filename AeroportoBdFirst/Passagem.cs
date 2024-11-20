using System;
using System.Collections.Generic;

namespace Teste;

public partial class Passagem
{
    public int IdPassagem { get; set; }

    public int? NumeroPassagem { get; set; }

    public int ClientePassagemId { get; set; }

    public int VooNum { get; set; }

    public int PoltronaId { get; set; }

    public int AeroportoPartidaId { get; set; }

    public int AeroportoDestinoId { get; set; }

    public virtual Aeroporto AeroportoDestino { get; set; } = null!;

    public virtual Aeroporto AeroportoPartida { get; set; } = null!;

    public virtual Cliente ClientePassagem { get; set; } = null!;

    public virtual Poltrona Poltrona { get; set; } = null!;

    public virtual Voo VooNumNavigation { get; set; } = null!;
}
