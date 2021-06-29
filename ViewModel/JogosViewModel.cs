using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroJogos.ViewModel
{
    public class JogosViewModel
    {
        public Guid id { get; set; }
        public string nome { get; set; }
        public string produtora { get; set; }
        public double preco { get; set; }
    }
}

