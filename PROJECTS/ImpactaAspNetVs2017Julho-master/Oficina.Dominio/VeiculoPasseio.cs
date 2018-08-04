using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oficina.Dominio
{
    // ToDo: OO - classe ou abstração
    // ToDo: OO - Veiculo heranca
    public class VeiculoPasseio:Veiculo
    {
        public TipoCarroceria Carroceria { get; set; }

        public override List<string> Validar()
        {
            var erros = base.ValidarBase();

            if (!Enum.IsDefined(typeof(TipoCarroceria), Carroceria))
            {
                erros.Add($"A carroceria informada ({Carroceria}) não é válida.");
            }

            return erros;
        }
    }
}
