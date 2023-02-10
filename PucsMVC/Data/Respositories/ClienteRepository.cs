using Microsoft.EntityFrameworkCore;
using PucsMVC.Helpers;
using PucsMVC.Interfaces.Repositories;
using PucsMVC.Models.EF;

namespace PucsMVC.Data.Respositories
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(ApplicationDbContext context) : base(context)
        {
        }

        public List<Cliente> GetAllByRequest(DataTableRequest query)
        {
            var consulta = Db.Clientes
                 .AsNoTracking()
                 .Select(c => new Cliente
                 {
                     Id = c.Id,
                     RazaoSocial = c.RazaoSocial,
                     CNPJ = c.CNPJ,
                     DataNascimento = c.DataNascimento,
                     Email = c.Email,
                 });
            return consulta.ToList();
        }
    }
}
