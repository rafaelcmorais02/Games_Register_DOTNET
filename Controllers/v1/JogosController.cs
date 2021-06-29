using CadastroJogos.Exceptions;
using CadastroJogos.InputModel;
using CadastroJogos.Services;
using CadastroJogos.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroJogos.Controllers.v1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JogosController : ControllerBase
    {
        private readonly IJogoService _jogoService;

        public JogosController(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }
        /// <summary>
        /// Busca todos os jogos de forma paginada
        /// </summary>
        /// <param name="pagina">Pagina para buscar os jogos</param>
        /// <param name="quantidade">Número de jogos</param>
        /// <returns>Retorna a lista de jogos</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<JogosViewModel>>> Obter([FromQuery, Range(1, int.MaxValue)] int pagina =1, [FromQuery, Range(1, 50)] int quantidade = 5)
        {
            var jogos = await _jogoService.Obter(pagina, quantidade);
            if (jogos.Count() == 0)
                return NoContent();
            return Ok(jogos);
        }
        /// <summary>
        /// Busca um jogo através de seu ID
        /// </summary>
        /// <param name="idJogo">Id do jogo</param>
        /// <returns>Retorna um jogo apenas</returns>
        [HttpGet("{idJogo:guid}")]
        public async Task<ActionResult<JogosViewModel>> Obter([FromRoute] Guid idJogo)
        {
            var jogo = await _jogoService.Obter(idJogo);
            if (jogo == null)
                return NoContent();
            return Ok(jogo);
        }
        /// <summary>
        /// Insere um jogo no banco de dados
        /// </summary>
        /// <param name="jogosInputModel">Parâmetros de cadastro</param>
        /// <returns>Retorna o jogo cadastrado</returns>
        [HttpPost]
        public async Task<ActionResult<JogosViewModel>> InserirJogo([FromBody] JogosInputModel jogosInputModel)
        {
            try
            {
                var jogo = await _jogoService.Inserir(jogosInputModel);
                return Ok(jogo);
            }
            catch (jogoJaCadastrado ex)
            {
                return UnprocessableEntity("Jogo já cadastrado");
            }
        }
        /// <summary>
        /// Atualiza um jogo, por id
        /// </summary>
        /// <param name="idJogo">id do jogo</param>
        /// <param name="jogosInputModel">parâmetros que serão atualizados</param>
        /// <returns></returns>
        [HttpPut("{idJogo:guid}")]
        public async Task<ActionResult> AtualizaJogo([FromRoute]Guid idJogo, [FromBody] JogosInputModel jogosInputModel)
        {
            try
            {
                await _jogoService.Atualizar(idJogo, jogosInputModel);
                return Ok();
            }
            catch (jogoNaoExiste ex)
            {
                return NotFound("Não foi encontrado jogo para atualizar");
            }

        }
        /// <summary>
        /// Atualiza o valor de um jogo por id
        /// </summary>
        /// <param name="idJogo">id do jogo</param>
        /// <param name="preco">preço que será atualizado</param>
        /// <returns></returns>
        [HttpPatch("{idJogo:guid}/preco/{preco:double}")]
        public async Task<ActionResult> AtualizaJogo([FromRoute] Guid idJogo, [FromRoute] double preco)
        {
            try
            {
                await _jogoService.Atualizar(idJogo,preco);
                return Ok();
            }
            catch (jogoNaoExiste ex)
            {
                return NotFound("Não foi encontrado jogo para atualizar");
            }
        }
        /// <summary>
        /// Deleta um jogo através de seu id
        /// </summary>
        /// <param name="idJogo">id do jogo</param>
        /// <returns></returns>
        [HttpDelete("{idJogo:guid}")]
        public async Task<ActionResult> DeletaJogo([FromRoute] Guid idJogo)
        {
            try
            {
                await _jogoService.Deletar(idJogo);
                return Ok();
            }
            catch(jogoNaoExiste ex)
            {
                return NotFound("Não foi encontrado jogo para deletar");
            }
        }
    }
}
