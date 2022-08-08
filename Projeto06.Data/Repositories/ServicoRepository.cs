using Projeto06.Data.Contexts;
using Projeto06.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto06.Data.Repositories
{
    internal class ServicoRepository : BaseRepository<Servico, Guid>
    {
        public ServicoRepository(DataContext? dataContext) : base(dataContext)
        {
        }
    }
}
