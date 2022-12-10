using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Expression
{
    public abstract class TokenBase
    {
        public abstract TipoToken TipoToken { get; }
        public abstract IEnumerable<TokenBase> GetFigli();

    }
}
