using System.Web.Mvc;
using TesteAPIBd.GGGFaria.Domain;
using TesteAPIBd.GGGFaria.ServiceAPI.Base;

namespace TesteAPIBd.GGGFaria.Controllers
{
    public class HomeController : Controller
    {
        private CrudAPIService _crudAPI = new CrudAPIService();

        public HomeController()
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreatePost(int id)
        {

            var post = _crudAPI.SelectAll<Post>($"posts/{id}");
            if(post == null)
                return View("Index");

            return View("Sucesso");

        }

    }
}