using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroJogos.InputModel
{
    public class JogosInputModel
    {
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage = "O nome do jogo deve conter entre 3 e 100 caracters")]
        public string nome { get; set; }
        [Required]
        [StringLength(100, MinimumLength =3, ErrorMessage ="O nome da produtora deve conter entre 3 e 100 caracteres")]
        public string produtora { get; set; }
        [Required]
        [Range(1,100,ErrorMessage ="O preço deve ser de no mínimo 1 real e de no máximo 1000 reais")]
        public double preco { get; set; }
    }
}
