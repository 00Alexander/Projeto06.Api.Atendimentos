using Projeto06.Data.Contexts;
using Projeto06.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Data.Repositories
{
    public class AtendimentoRepository : BaseRepository<Cliente, Guid>
    {
        public AtendimentoRepository(DataContext? dataContext) : base(dataContext)
        {
        }
    }
}
