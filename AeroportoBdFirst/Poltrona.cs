﻿using System;
using System.Collections.Generic;

namespace Teste;

public partial class Poltrona
{
    public int IdPoltrona { get; set; }

    public string? NumPoltrona { get; set; }

    public bool? Ocupado { get; set; }

    public virtual ICollection<Passagem> Passagems { get; set; } = new List<Passagem>();
}
