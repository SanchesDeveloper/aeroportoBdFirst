using System;
using System.Collections.Generic;

namespace Teste;

public partial class Aeroporto
{
    public int IdAeroporto { get; set; }

    public string? Nome { get; set; }

    public int CidadeId { get; set; }

    public string? Cnpj { get; set; }

    public string? Sigla { get; set; }

    public virtual Cidade Cidade { get; set; } = null!;

    public virtual ICollection<Passagem> PassagemAeroportoDestinos { get; set; } = new List<Passagem>();

    public virtual ICollection<Passagem> PassagemAeroportoPartida { get; set; } = new List<Passagem>();

    public virtual ICollection<Voo> VooDestinos { get; set; } = new List<Voo>();

    public virtual ICollection<Voo> VooPartida { get; set; } = new List<Voo>();
}
