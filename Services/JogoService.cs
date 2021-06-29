using CadastroJogos.Entities;
using CadastroJogos.Exceptions;
using CadastroJogos.InputModel;
using CadastroJogos.Repositorio;
using CadastroJogos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroJogos.Services
{
    public class JogoService : IJogoService
    {
        private readonly IJogoRepositorio _jogoRepositorio;

        public JogoService(IJogoRepositorio jogoRepositorio)
        {
            _jogoRepositorio = jogoRepositorio;
        }
        public async Task<List<JogosViewModel>> Obter(int pagina, int quantidade)
        {
            var jogos = await _jogoRepositorio.Obter(pagina, quantidade);
            return jogos.Select(jogo => new JogosViewModel
            {
                id = jogo.id,
                nome = jogo.nome,
                produtora = jogo.produtora,
                preco = jogo.preco
            }).ToList();
        }
        public async Task<JogosViewModel> Obter(Guid id)
        {
            var jogo = await _jogoRepositorio.Obter(id);
            if (jogo == null)
                return null;
            return new JogosViewModel
            {
                id = jogo.id,
                nome = jogo.nome,
                produtora = jogo.produtora,
                preco = jogo.preco
            };
        }

        public async Task<JogosViewModel> Inserir(JogosInputModel jogo)
        {
            var entidadeJogo = await _jogoRepositorio.Obter(jogo.nome, jogo.produtora);
            if (entidadeJogo.Count() > 0)
                throw new jogoJaCadastrado();

            var jogoInsert = new Jogo
            {
                id = Guid.NewGuid(),
                nome = jogo.nome,
                produtora = jogo.produtora,
                preco = jogo.preco
            };

            await _jogoRepositorio.Inserir(jogoInsert);

            return new JogosViewModel
            {
                id = jogoInsert.id,
                nome = jogoInsert.nome,
                produtora = jogoInsert.produtora,
                preco = jogoInsert.preco
            };
        }
        public async Task Atualizar(Guid id, JogosInputModel jogo)
        {
            var entidadeJogo = await _jogoRepositorio.Obter(id);
            if (entidadeJogo == null)
                throw new jogoNaoExiste();
            entidadeJogo.nome = jogo.nome;
            entidadeJogo.preco = jogo.preco;
            entidadeJogo.produtora = jogo.produtora;
            await _jogoRepositorio.Atualizar(entidadeJogo);
        }
        public async Task Atualizar(Guid id, double preco)
        {
            var entidadeJogo = await _jogoRepositorio.Obter(id);
            if (entidadeJogo == null)
                throw new jogoNaoExiste();
            entidadeJogo.preco = preco;
            await _jogoRepositorio.Atualizar(entidadeJogo);
        }
        public async Task Deletar(Guid id)
        {
            var entidadeJogo = await _jogoRepositorio.Obter(id);
            if (entidadeJogo == null)
                throw new jogoNaoExiste();
            await _jogoRepositorio.Deletar(id);
        }
        public void Dispose()
        {
            _jogoRepositorio?.Dispose();
        }
    }
}
