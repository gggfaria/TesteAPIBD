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

        [HttpGet]
        public ActionResult GetPostById(int id)
        {

            var post = _crudAPI.Get<Post>($"posts/{id}");
            if(post == null)
                return View("Index");

            return Json(post, JsonRequestBehavior.AllowGet);

        }

    }
}