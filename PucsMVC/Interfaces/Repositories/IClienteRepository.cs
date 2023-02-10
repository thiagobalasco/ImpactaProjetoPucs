using PucsMVC.Helpers;
using PucsMVC.Models.EF;

namespace PucsMVC.Interfaces.Repositories
{
    public interface IClienteRepository : IRepositoryBase<Cliente>
    {
        List<Cliente> GetAllByRequest(DataTableRequest query);
    }
}
