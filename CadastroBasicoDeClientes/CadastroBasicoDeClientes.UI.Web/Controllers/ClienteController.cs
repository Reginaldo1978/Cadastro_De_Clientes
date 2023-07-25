using CadastroBasicoDeClientes.Cliente_Dao;
using CadastroBasicoDeClientes.Dominio;
using System.Web.Mvc;

namespace CadastroBasicoDeClientes.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteDao clienteDao;
        public ClienteController()
        {
            clienteDao = ClienteDaoConstrutor.ClienteDaoEF();
        }
        public ActionResult Index()
        {
            var listaDeClientes = clienteDao.ListarTodos();
            return View(listaDeClientes);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastrar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteDao.Salvar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Editar(string id)
        {
            var cliente = clienteDao.ListarPorId(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                clienteDao.Salvar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalhes(string id)
        {
            var cliente = clienteDao.ListarPorId(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        public ActionResult Excluir(string id) 
        {
            var cliente = clienteDao.ListarPorId(id);

            if (cliente == null)
                return HttpNotFound();
            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(string id) 
        {
            var cliente = clienteDao.ListarPorId(id);
            clienteDao.Excluir(cliente);
            return RedirectToAction("Index");
        }
    }
}