using System;
using System.Collections.Generic;

namespace Oficina.Dominio
{
    public abstract class Veiculo
    {
        //public Veiculo()
        //{
        //    Id = Guid.NewGuid();
        //}

        public Guid Id { get; set; } = Guid.NewGuid();
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string Observacao { get; set; }

        public Modelo Modelo { get; set; }
        public Cor Cor { get; set; }

        public Combustivel Combustivel { get; set; }
        public Cambio Cambio { get; set; }

        public abstract List<string> Validar();

        protected List<string> ValidarBase()
        {
            var erros = new List<String>();

            if(Ano <= 1940 || (Ano-DateTime.Now.Year >= 2))
            {
                erros.Add($"O ano informado {Ano} é invalido.");

            }
            return erros;
        }

        
    }
}
