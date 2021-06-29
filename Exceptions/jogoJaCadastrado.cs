using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroJogos.Exceptions
{
    public class jogoJaCadastrado : Exception
    {
        public jogoJaCadastrado() : base("Esse jogo já foi cadastrado")
        {}
    }
}
