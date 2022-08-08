using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Domain.Models
{
    public class Servico
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public decimal? Preco { get; set; }

        #endregion

        #region Associações

        public virtual ICollection<Atendimento>? Atendimentos { get; set; }
        public virtual ICollection<AtendimentoServico>? AtendimentosServicos { get; set; }

        #endregion
    }

}
