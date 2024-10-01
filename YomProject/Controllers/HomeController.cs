using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using yom_web.Models;
using YomProject.Models;

namespace yom_web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        [HttpGet]
        public IActionResult register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult register(HomeModel hm)
        {
            string name = hm.name;

            string email = hm.email;

            string password = hm.password;

            var query = hm.insert(name, email, password);

            return RedirectToAction("login");
        }


        [HttpGet]
        public IActionResult login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult login(HomeModel hm)
        {
            DataSet ds = hm.select(hm.email, hm.password);

            ViewBag.login_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;

                return RedirectToAction("Index");
            }
            return RedirectToAction("login");
        }

		[HttpGet]
		public IActionResult Index(SliderModel sm, OfferModel om , ThemeModel tm , RecentModel rm , CatModel cm )
        {
            DataSet ds = sm.select();
            ViewBag.ds = ds.Tables[0];

            DataSet ds2 = om.select();
            ViewBag.ds2 = ds2.Tables[0];

            DataSet ds3 = tm.select();
            ViewBag.ds3 = ds3.Tables[0];

            DataSet ds4 = rm.select();
            ViewBag.ds4 = ds4.Tables[0];

            DataSet ds5 = cm.select();
            ViewBag.ds5 = ds5.Tables[0];


			return View();
        }


        public IActionResult services(Offer2Model ofm , ThemeSeModel tsm)
        {
			DataSet ds = ofm.select();
			ViewBag.ds = ds.Tables[0];

            DataSet ds2 = tsm.select();
            ViewBag.ds2 = ds2.Tables[0];

            return View();
        }

        public IActionResult clients(ClientModel cm)
        {
            DataSet ds = cm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }

        public IActionResult bclassic(BlogModel bm)
        {
            DataSet ds = bm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }

        public IActionResult bgrid()
        {
            return View();
        }

        public IActionResult bpost(BlogPost bp , BlogSlider bs)
        {
            DataSet ds = bp.select();
            ViewBag.ds = ds.Tables[0];

			DataSet ds2 = bs.select();
			ViewBag.ds2 = ds2.Tables[0];

			return View();
        }

        public IActionResult about(TeamModel tm , A_ClientModel cm)
        {   
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];

			DataSet ds2 = cm.select();
			ViewBag.ds2 = ds2.Tables[0];

			return View();
        }

        public IActionResult three(ThreeModel tm)
        {
			DataSet ds = tm.select();
			ViewBag.ds = ds.Tables[0];

			return View();
        }

        public IActionResult four(FourModel fm)
        {
            DataSet ds = fm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }

        public IActionResult single(SingleModel sm , WorkModel wm , SingleSlider ss)
        {
            DataSet ds = sm.select();
            ViewBag.ds = ds.Tables[0];

            DataSet ds2 = wm.select();
            ViewBag.ds2 = ds2.Tables[0];

            DataSet ds3 = ss.select();
            ViewBag.ds3 = ds3.Tables[0];

            return View();
        }

        public IActionResult contact()
        {
            return View();
        }
        

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
