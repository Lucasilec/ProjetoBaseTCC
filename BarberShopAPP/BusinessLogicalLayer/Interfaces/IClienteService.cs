using BusinessLogicalLayer.Message;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Interfaces
{
    public interface IClienteService
    {
        Task<Response> Insert(Cliente cliente);
        Response Update(Cliente cliente);
        Response Delete(Cliente cliente);
        SingleResponse<Cliente> GetByID(int id);
        SingleResponse<Cliente> GetByCPF(string cpf);
        SingleResponse<Cliente> GetByEmail(string email);
        Task<QueryResponse<Cliente>> GetAll();
        QueryResponse<Cliente> GetActiveClients();
    }
}
