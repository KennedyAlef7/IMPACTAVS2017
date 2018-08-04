using System.ComponentModel;

namespace Oficina.Dominio
{
    public enum Cambio
    {
        Manual = 1,

        [DescriptionAttribute("Automático")]
        Automatico = 2,

        Automatizado = 3
    }
}