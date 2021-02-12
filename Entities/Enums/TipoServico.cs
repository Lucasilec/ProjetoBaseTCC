using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Enums
{
    [Flags]
    public enum TipoServico
    {
        Cabelo = 1,
        Barba = 2,
        Sobrancelha = 4,
        Bigode = 8,
    }
}
