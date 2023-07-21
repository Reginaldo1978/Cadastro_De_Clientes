using CadastroBasicoDeClientes.Cliente_Dao;
using CadastroBasicoDeClientes.Dominio;
using System.Web.Mvc;

namespace CadastroBasicoDeClientes.UI.Web.Controllers
{
    public class ClienteController : Controller
    {
        public ActionResult Index()
        {
            var clienteDao = new ClienteDao();
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
                var clienteDao = new ClienteDao();
                clienteDao.Salvar(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        public ActionResult Editar(int id)
        {
            var clienteDao = new ClienteDao();
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
                var clienteDao = new ClienteDao();
                clienteDao.Salvar(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        public ActionResult Detalhes(int id)
        {
            var clienteDao = new ClienteDao();
            var cliente = clienteDao.ListarPorId(id);

            if (cliente == null)
                return HttpNotFound();

            return View(cliente);
        }

        public ActionResult Excluir(int id) 
        {
            var clienteDao = new ClienteDao();
            var cliente = clienteDao.ListarPorId(id);

            if (clienteDao == null)
                return HttpNotFound();
            return View(cliente);
        }

        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public ActionResult ExcluirConfirmado(int id) 
        {
            var clienteDao = new ClienteDao();
            clienteDao.Excluir(id);
            return RedirectToAction("Index");
        }
    }
}