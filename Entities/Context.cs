using CadastroJogos.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace CadastroJogos
{
    public class Context:DbContext
    {
        public DbSet<Jogo> JogosTabela { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString:@"Server=(localdb)\mssqllocaldb;Database=JogosCadastrar;Integrated Security=true");
        }
    }
}
