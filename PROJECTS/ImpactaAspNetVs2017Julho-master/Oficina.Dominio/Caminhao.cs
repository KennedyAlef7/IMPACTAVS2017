﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    class Caminhao:Veiculo
    {
        public QuantidadeEixo GetQuantidadeEixo { get; set; }

        public override List<string> Validar()
        {
            throw new NotImplementedException();
        }
    }
}
