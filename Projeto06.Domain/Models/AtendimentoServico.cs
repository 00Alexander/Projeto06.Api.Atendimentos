using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Domain.Models
{
    public class AtendimentoServico
    {
        #region Propriedades

        public Guid AtendimentoId { get; set; }
        public Guid ServicoId { get; set; }

        #endregion

        #region Associações

        public Atendimento? Atendimento { get; set; }
        public Servico? Servico { get; set; }

        #endregion

    }
}
