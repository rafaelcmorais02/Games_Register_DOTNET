using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroJogos.Exceptions
{
    public class jogoNaoExiste : Exception
    {
        public jogoNaoExiste() : base("Jogo Não Existe")
        {}
    }
}
