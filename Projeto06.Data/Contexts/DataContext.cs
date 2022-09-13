using Microsoft.EntityFrameworkCore;
using Projeto06.Data.Mappings;
using Projeto06.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Data.Contexts
{
    public class DataContext : DbContext
    {
        public DbSet<Cliente>? Atendimentos { get; set; }
        public DbSet<Cliente>? Clientes { get; set; }
        public DbSet<Servico>? Servicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DBProjeto06;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AtendimentoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ServicoMap());
        }
    }
}
