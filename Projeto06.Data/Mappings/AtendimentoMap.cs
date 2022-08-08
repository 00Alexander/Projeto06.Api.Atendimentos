using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto06.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Data.Mappings
{
    public class AtendimentoMap : IEntityTypeConfiguration<Atendimento>
    {
        public void Configure(EntityTypeBuilder<Atendimento> builder)
        {
            #region Relacionamento 1pN

            builder.HasOne(a => a.Cliente)
                .WithMany(c => c.Atendimentos)
                .HasForeignKey(a => a.ClienteId);

            #endregion

            #region Relacionamento NpN

            builder.HasMany(a => a.Servicos)
                .WithMany(s => s.Atendimentos)
                .UsingEntity<AtendimentoServico>(
                    map => map
                        .HasOne(map => map.Servico)
                        .WithMany(s => s.AtendimentosServicos)
                        .HasForeignKey(map => map.ServicoId),
                    map => map
                        .HasOne(map => map.Atendimento)
                        .WithMany(a => a.AtendimentosServicos)
                        .HasForeignKey(map => map.AtendimentoId),
                    map =>
                    {
                        map.HasKey(ats => new { ats.AtendimentoId, ats.ServicoId });
                    });

            #endregion


        }
    }
}
