using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Domain.Models
{
    public class Atendimento
    {
        #region Propriedades

        public Guid Id { get; set; }
        public DateTime? Data { get; set; }
        public TimeSpan? Hora { get; set; }
        public decimal? Valor { get; set; }
        public string? Observacoes { get; set; }
        public Guid ClienteId { get; set; }

        #endregion

        #region Associações

        public virtual Cliente? Cliente { get; set; }
        public virtual ICollection<Servico>? Servicos { get; set; }
        public virtual ICollection<AtendimentoServico>? AtendimentosServicos { get; set; }

        #endregion
    }
}


