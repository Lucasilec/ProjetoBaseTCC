using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Message;
using DataAccessLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicalLayer.Implementation
{
    public class ClienteService : BaseValidator<Cliente>, IClienteService
    {
        //private ILog log;
        //private ICacheService cache;

        //public ClienteService(ILog log, ICacheService cache)
        //{
        //    this.cache = cache
        //    this.log = log;
        //}

        public override Response Validate(Cliente item)
        {
            if (string.IsNullOrWhiteSpace(item.Nome))
            {
                this.AddError("O nome deve ser informado.");
            }
            else if(item.Nome.Length < 3 || item.Nome.Length > 50)
            {
                this.AddError("Nome deve estar entre 3 e 50 caracteres.");
            }
            return base.Validate(item);
        }

        public async Task<Response> Insert(Cliente cliente)
        {
            Response response = Validate(cliente);
            if (!response.Sucesso)
            {
                return response;
            }
            try
            {
                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    db.Clientes.Add(cliente);
                    await db.SaveChangesAsync();
                    response.Sucesso = true;
                    response.Mensagem = "Cliente cadastrado com sucesso.";
                    return response;
                        
                }
            }
            catch (Exception ex)
            {
                //if(ex.Message.Contains("CPF"))
                Response r = new Response();
                r.Sucesso = false;
                r.Exception = ex.Message;
                r.Mensagem = "Erro no banco de dados, contate o administrador.";
                return r;
            }
        }

        public Response Update(Cliente cliente)
        {
            Response response = Validate(cliente);
            if (!response.Sucesso)
            {
                return response;
            }
            try
            {
                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    db.Entry(cliente).State = System.Data.Entity.EntityState.Modified;

                    response.Sucesso = true;
                    response.Mensagem = "Cliente atualizado com sucesso.";
                    return response;

                }
            }
            catch (Exception ex)
            {
                //log.Log(ex);

                //if(ex.Message.Contains("CPF"))
                Response r = new Response();
                r.Sucesso = false;
                r.Exception = ex.Message;
                r.Mensagem = "Erro no banco de dados, contate o administrador.";
                return r;
            }
        }

        public Response Delete(Cliente cliente)
        {
            Response response = Validate(cliente);
            if (!response.Sucesso)
            {
                return response;
            }
            try
            {
                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    db.Entry(cliente).State = System.Data.Entity.EntityState.Deleted;

                    response.Sucesso = true;
                    response.Mensagem = "Cliente excluído com sucesso.";
                    return response;

                }
            }
            catch (Exception ex)
            {
                //if(ex.Message.Contains("CPF"))
                Response r = new Response();
                r.Sucesso = false;
                r.Exception = ex.Message;
                r.Mensagem = "Erro no banco de dados, contate o administrador.";
                return r;
            }
        }

        public QueryResponse<Cliente> GetActiveClients()
        {
            QueryResponse<Cliente> responseClientes = new QueryResponse<Cliente>();

            try
            {
                //if (cache.Get("Cliente") != null)
                //{
                //    return cache.Get("CLiente")
                //}

                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    List<Cliente> clientesAtivos = db.Clientes.Where(c => c.Ativo).ToList();

                    responseClientes.Data = clientesAtivos;
                    responseClientes.Sucesso = true;
                    return responseClientes;

                }
            }
            catch (Exception ex)
            {
                responseClientes.Sucesso = false;
                responseClientes.Exception = ex.Message;
                responseClientes.Mensagem = "Erro no banco de dados, contate o administrador.";
                return responseClientes;
            }
        }

        public async Task<QueryResponse<Cliente>> GetAll()
        {
            QueryResponse<Cliente> responseClientes = new QueryResponse<Cliente>();

            try
            {
                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    List<Cliente> clientesAtivos = await db.Clientes.ToListAsync();

                    responseClientes.Data = clientesAtivos;
                    responseClientes.Sucesso = true;
                    return responseClientes;

                }
            }
            catch (Exception ex)
            {
                responseClientes.Sucesso = false;
                responseClientes.Exception = ex.Message;
                responseClientes.Mensagem = "Erro no banco de dados, contate o administrador.";
                return responseClientes;
            }
        }

        public SingleResponse<Cliente> GetByCPF(string cpf)
        {
            SingleResponse<Cliente> responseClientes = new SingleResponse<Cliente>();

            try
            {
                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    Cliente cliente = db.Clientes.FirstOrDefault(c=> c.CPF == cpf);
                    responseClientes.SingleData = cliente;
                    responseClientes.Sucesso = true;
                    return responseClientes;
                }
            }
            catch (Exception ex)
            {
                responseClientes.Sucesso = false;
                responseClientes.Exception = ex.Message;
                responseClientes.Mensagem = "Erro no banco de dados, contate o administrador.";
                return responseClientes;
            }
        }

        public SingleResponse<Cliente> GetByEmail(string email)
        {
            SingleResponse<Cliente> responseClientes = new SingleResponse<Cliente>();
            try
            {
                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    Cliente cliente = db.Clientes.FirstOrDefault(c => c.Email == email);
                    responseClientes.SingleData = cliente;
                    responseClientes.Sucesso = true;
                    return responseClientes;

                }
            }
            catch (Exception ex)
            {
                responseClientes.Sucesso = false;
                responseClientes.Exception = ex.Message;
                responseClientes.Mensagem = "Erro no banco de dados, contate o administrador.";
                return responseClientes;
            }
        }

        public SingleResponse<Cliente> GetByID(int id)
        {
            SingleResponse<Cliente> responseClientes = new SingleResponse<Cliente>();

            try
            {
                using (BarberShopDbContext db = new BarberShopDbContext())
                {
                    Cliente cliente = db.Clientes.Find(id);
                    responseClientes.SingleData = cliente;
                    responseClientes.Sucesso = true;
                    return responseClientes;
                }
            }
            catch (Exception ex)
            {
                responseClientes.Sucesso = false;
                responseClientes.Exception = ex.Message;
                responseClientes.Mensagem = "Erro no banco de dados, contate o administrador.";
                return responseClientes;
            }
        }
    }
}
