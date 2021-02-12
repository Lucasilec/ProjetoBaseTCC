using AutoMapper;
using BusinessLogicalLayer.Implementation;
using BusinessLogicalLayer.Interfaces;
using BusinessLogicalLayer.Message;
using Entities;
using MVCPresentatoinLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;

namespace MVCPresentatoinLayer.Controllers
{
    //TDD
    //Autenticação -> Cookies
    //Framework Front-End -> Vue.JS / React
    //Controle de Cache (Reddis)
    //Log de Erros (Log4Net)
    //Multi-thread
    //1)Retorno deve ser Task
    //2)Deve possuir a keyword async na assinatura do método
    //3)Deve possuir a keyword await na chamada do método assíncrono

    //Injeção de Dependência

    //Assert(db.Clientes.Count,0);
    //Response r = svc.Insert(cliente);
    //Assert(r.Success, true)
    //Assert(db.Clientes.Count,1);


    public class ClienteController : Controller
    {
        private ClienteService svc = new ClienteService();

        public async Task<ActionResult> Index()
        {
            QueryResponse<Cliente> response = await svc.GetAll();
            
            if(!response.Sucesso)
            {
                ViewBag.Erros = "Não foi possível encontrar os dados.";
                return View();
            }
            List<Cliente> clientes = response.Data;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteQueryViewModel>());
            var mapper = config.CreateMapper();
            List<ClienteQueryViewModel> dados = mapper.Map<List<ClienteQueryViewModel>>(clientes);
            return View(dados);
        }

        [OutputCache(Duration = int.MaxValue)]
        public ActionResult Inserir()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Edit(ClienteUpdateViewModel viewModel)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteUpdateViewModel, Cliente>());
            var mapper = config.CreateMapper();
            Cliente cliente = mapper.Map<Cliente>(viewModel);

            Response response = svc.Update(cliente);
            if (response.Sucesso)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Erros = response.Mensagem;
            return View();
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            SingleResponse<Cliente> responseCliente = svc.GetByID(id.Value);
            if (!responseCliente.Sucesso)
            {
                return RedirectToAction("Index");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Cliente, ClienteUpdateViewModel>());
            var mapper = config.CreateMapper();
            ClienteUpdateViewModel cliente = 
                mapper.Map<ClienteUpdateViewModel>(responseCliente.SingleData);

            return View(cliente);
        }

        //MÉTODO HTTP POST
        [HttpPost]
        public async Task<ActionResult> Inserir(ClienteInsertViewModel viewModel)
        {

            var config = new MapperConfiguration(cfg => cfg.CreateMap<ClienteInsertViewModel, Cliente>());
            var mapper = config.CreateMapper();
            Cliente cliente = mapper.Map<Cliente>(viewModel);

            Response response = await svc.Insert(cliente);
            if (response.Sucesso)
            {
                return RedirectToAction("Index");
            }

            ViewBag.Erros = response.Mensagem;
            return View();
        }
    }

    //Exemplo de CustomAutoMapper criado em sala (utilizem o AUtoMapper mostrado no exemplo do controller que é 
    //o jeito em que as empresas usam
    public static class AutoMapper<T,W>
    {
        public static T Map(W item)
        {
            T t = Activator.CreateInstance<T>();
            PropertyInfo[] propriedades = typeof(W).GetProperties();

            foreach (PropertyInfo propriedade in propriedades)
            {
                try
                {
                    //cliente.Nome = clienteViewModel.Nome;
                    typeof(T).GetProperty(propriedade.Name).SetValue(t, propriedade.GetValue(item));
                }
                catch 
                {
                }
            }

            return t;
        }

    }

}