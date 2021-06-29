using CadastroJogos.Entities;
using CadastroJogos.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadastroJogos.Repositorio
{
    public class JogoRepositorio: IJogoRepositorio
    {

        public Context context;
        public JogoRepositorio()
        {
            context = new Context();
        }

        public Task<List<Jogo>> Obter(int pagina, int quantidade)
        {
            return Task.FromResult(context.JogosTabela.Skip((pagina - 1) * quantidade).Take(quantidade).ToList());
        }
        public Task<List<Jogo>> Obter(string nome, string produtora)
        {
                List<Jogo> ob = context.JogosTabela.Where(jogo => jogo.nome.Equals(nome) && jogo.produtora.Equals(produtora)).ToList();
                return Task.FromResult(ob);
        }
        public Task<Jogo> Obter(Guid id)
        {
            try
            {
                Jogo ob = context.JogosTabela.Find(id);
                return Task.FromResult(ob);
            }
            catch
            {
                return null;
            }
        }
        public Task Inserir(Jogo jogo)
        {
            context.JogosTabela.Add(jogo);
            context.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Deletar(Guid id)
        {
            Jogo ob = context.JogosTabela.Find(id);
            context.JogosTabela.Remove(ob);
            context.SaveChanges();
            return Task.CompletedTask;
        }
        public Task Atualizar(Jogo jogo)
        {
            Jogo ob = context.JogosTabela.Find(jogo.id);
            context.JogosTabela.Update(ob);
            context.SaveChanges();
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            context.Dispose();
        }
    }
}
