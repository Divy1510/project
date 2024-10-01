using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using YomProject.Models;

namespace YomProject.Controllers
{
    public class AdminController : Controller

    {
        private readonly IWebHostEnvironment _environment;

        public AdminController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet]
        public IActionResult index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult index(AdminModel am)
        {
            DataSet ds = am.select(am.email, am.password);

            ViewBag.login_data = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.login_data.Rows)
            {
                var id = dr["id"].ToString();
                TempData["id"] = id;

                return RedirectToAction("Deshboard1");
            }
            return RedirectToAction("index");
        }





        //Slider--------------------------------------------------------------------------------------------------------------------------------


        [HttpGet]
        public IActionResult delete(SliderModel sm, int id)
        {
            sm.Delete(id);

            return RedirectToAction("view_slider");
        }

        [HttpGet]
        public IActionResult update(SliderModel sm, int id)
        {
            DataSet ds = sm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> update(SliderModel sm, int id, int a = 0)
        {
            string title = sm.title;
            string description = sm.description;

            var filename = "";

            if (sm.image != null && sm.image.Length > 0)
            {
                filename = Path.GetFileName(sm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await sm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            sm.update_data(id, title, description, filename);

            return RedirectToAction("view_slider");
        }

        [HttpPost]
        public async Task<ActionResult> add_slider(SliderModel sm)
        {
            string title = sm.title;
            string description = sm.description;

            if (sm.image != null && sm.image.Length > 0)
            {
                string filename = Path.GetFileName(sm.image.FileName);
                string fileuplod = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileuplod, FileMode.Create))
                {
                    await sm.image.CopyToAsync(str);
                }
                sm.insert(title, description, filename);
            }


            return RedirectToAction("add_slider");
        }

        public IActionResult view_slider(SliderModel sm)
        {
            DataSet ds = sm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        [HttpGet]
        public IActionResult add_slider()
        {
            return View();
        }




        //Offer--------------------------------------------------------------------------------------------------------------------------------



        [HttpGet]
        public IActionResult add_offer()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_offer(OfferModel om)
        {
            string icon = om.icon;
            string title = om.title;
            string description = om.description;

            om.insert(icon, title, description);

            return View("add_offer");
        }

        public IActionResult view_offer(OfferModel om)
        {
            DataSet ds = om.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }

        [HttpGet]
        public IActionResult delete_o(OfferModel om, int id)
        {
            om.Delete_o(id);

            return RedirectToAction("view_offer");
        }


        [HttpGet]
        public IActionResult update_o(OfferModel om, int id)
        {
            DataSet ds = om.update_o(id);
            ViewBag.ds = ds.Tables[0];



            return View();
        }

        [HttpPost]
        public IActionResult update_o(OfferModel om, int id, int a = 0)
        {
            string icon = om.icon;
            string title = om.title;
            string description = om.description;

            om.update_o(id, icon, title, description);

            return RedirectToAction("view_offer");
        }



        //Recent--------------------------------------------------------------------------------------------------------------------------------



        [HttpGet]
        public IActionResult add_recent()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_recent(RecentModel rm)
        {
            string title = rm.title;
            string description = rm.description;

            if (rm.image != null && rm.image.Length > 0)
            {
                string filename = Path.GetFileName(rm.image.FileName);
                string fileuplod = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileuplod, FileMode.Create))
                {
                    await rm.image.CopyToAsync(str);
                }
                rm.insert(title, description, filename);
            }


            return View();
        }

        public IActionResult view_recent(RecentModel rm)
        {
            DataSet ds = rm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        [HttpGet]
        public IActionResult delete_re(RecentModel rm, int id)
        {
            rm.Delete_re(id);

            return RedirectToAction("view_recent");
        }

        [HttpGet]
        public IActionResult update_re(RecentModel rm, int id)
        {
            DataSet ds = rm.update_re(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> update_re(RecentModel rm, int id, int a = 0)
        {
            string title = rm.title;
            string description = rm.description;

            var filename = "";

            if (rm.image != null && rm.image.Length > 0)
            {
                filename = Path.GetFileName(rm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await rm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            rm.update_data(id, title, description, filename);

            return RedirectToAction("view_recent");
        }


        //Theme--------------------------------------------------------------------------------------------------------------------------------



        [HttpGet]
        public IActionResult add_theme()
        {
            return View();
        }


        [HttpGet]
        public IActionResult delete_t(ThemeModel tm, int id)
        {
            tm.Delete_t(id);

            return RedirectToAction("view_theme");
        }


        [HttpPost]
        public async Task<ActionResult> add_theme(ThemeModel tm)
        {
            string heading = tm.heading;
            string title = tm.title;
            string description = tm.description;


            if (tm.image != null && tm.image.Length > 0)
            {
                string filename = Path.GetFileName(tm.image.FileName);
                string fileuplod = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileuplod, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }
                tm.insert(heading, title, description, filename);
            }

            return RedirectToAction("add_theme");
        }

        public ActionResult view_theme(ThemeModel tm)
        {
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        [HttpGet]
        public IActionResult update_t(ThemeModel tm, int id)
        {
            DataSet ds = tm.update_t(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> update_t(ThemeModel tm, int id, int a = 0)
        {
            string heading = tm.heading;
            string title = tm.title;
            string description = tm.description;

            var filename = "";

            if (tm.image != null && tm.image.Length > 0)
            {
                filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            tm.update_data(id, heading, title, description, filename);

            return RedirectToAction("view_theme");
        }


        //Category--------------------------------------------------------------------------------------------------------------------------------



        [HttpGet]
        public IActionResult add_cat()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_cat(CatModel cm)
        {
            string title = cm.title;
            string name = cm.name;
            string date = cm.date;
            string country = cm.country;
            string description = cm.description;

            if (cm.image != null && cm.image.Length > 0)
            {
                string filename = Path.GetFileName(cm.image.FileName);
                string fileuplod = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileuplod, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }
                cm.insert(filename, title, name, date, country, description);
            }


            return View();
        }

        public IActionResult view_cat(CatModel cm)
        {
            DataSet ds = cm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        [HttpGet]
        public IActionResult delete_cat(CatModel cm, int id)
        {
            cm.delete_cat(id);

            return RedirectToAction("view_cat");
        }

        [HttpGet]
        public IActionResult update_cat(CatModel cm, int id)
        {
            DataSet ds = cm.update_cat(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> update_cat(CatModel cm, int id, int a = 0)
        {
            string title = cm.title;
            string name = cm.name;
            string date = cm.date;
            string country = cm.country;
            string description = cm.description;

            var filename = "";

            if (cm.image != null && cm.image.Length > 0)
            {
                filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            cm.update_cat(id, filename, title, name, date, country, description);

            return RedirectToAction("view_cat");
        }



        //Offer--------------------------------------------------------------------------------------------------------------------------------



        [HttpGet]
        public IActionResult add_offer2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_offer2(Offer2Model ofm)
        {
            string icon = ofm.icon;
            string title = ofm.title;
            string description = ofm.description;

            ofm.insert(icon, title, description);

            return View("add_offer2");
        }

        public IActionResult view_offer2(Offer2Model ofm)
        {
            DataSet ds = ofm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }

        [HttpGet]
        public IActionResult delete_off(Offer2Model ofm, int id)
        {
            ofm.Delete_off(id);

            return RedirectToAction("view_offer2");
        }


        [HttpGet]
        public IActionResult update_off(Offer2Model ofm, int id)
        {
            DataSet ds = ofm.update_off(id);
            ViewBag.ds = ds.Tables[0];

            return View();
        }

        [HttpPost]
        public IActionResult update_off(Offer2Model ofm, int id, int a = 0)
        {
            string icon = ofm.icon;
            string title = ofm.title;
            string description = ofm.description;

            ofm.update_off(id, icon, title, description);

            return RedirectToAction("view_offer2");
        }


        //Theme--------------------------------------------------------------------------------------------------------------------------------



        [HttpGet]
        public IActionResult add_theme2()
        {
            return View();
        }


        [HttpGet]
        public IActionResult delete_the(ThemeSeModel tsm, int id)
        {
            tsm.Delete_the(id);

            return RedirectToAction("view_theme2");
        }


        [HttpPost]
        public async Task<ActionResult> add_theme2(ThemeSeModel tsm)
        {
            string heading = tsm.heading;
            string title = tsm.title;
            string description = tsm.description;


            if (tsm.image != null && tsm.image.Length > 0)
            {
                string filename = Path.GetFileName(tsm.image.FileName);
                string fileuplod = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileuplod, FileMode.Create))
                {
                    await tsm.image.CopyToAsync(str);
                }
                tsm.insert(heading, title, description, filename);
            }

            return RedirectToAction("add_theme2");
        }


        public ActionResult view_theme2(ThemeSeModel tsm)
        {
            DataSet ds = tsm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        [HttpGet]
        public IActionResult update_the(ThemeSeModel tsm, int id)
        {
            DataSet ds = tsm.update_the(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> update_the(ThemeSeModel tsm, int id, int a = 0)
        {
            string heading = tsm.heading;
            string title = tsm.title;
            string description = tsm.description;

            var filename = "";

            if (tsm.image != null && tsm.image.Length > 0)
            {
                filename = Path.GetFileName(tsm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tsm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            tsm.update_the(id, heading, title, description, filename);

            return RedirectToAction("view_theme2");
        }


        //clients--------------------------------------------------------------------------------------------------------------------------------


        [HttpGet]
        public IActionResult add_client()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_client(ClientModel cm)
        {
            if (cm.image != null && cm.image.Length > 0)
            {
                string filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }

                cm.insert(filename);
            }


            return RedirectToAction("add_client");
        }

        public IActionResult view_client(ClientModel cm)
        {
            DataSet ds = cm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }


        public IActionResult delete_cli(ClientModel cm, int id)
        {
            cm.Delete_cli(id);
            return RedirectToAction("view_client");
        }



        [HttpGet]
        public IActionResult update_cli(ClientModel cm, int id)
        {
            DataSet ds = cm.update_cli(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_cli(ClientModel cm, int id, int a = 0)
        {

            var filename = "";

            if (cm.image != null && cm.image.Length > 0)
            {
                filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            cm.update_data(id, filename);

            return RedirectToAction("view_client");
        }


        //Category--------------------------------------------------------------------------------------------------------------------------------

        [HttpGet]
        public IActionResult add_b_clas()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> add_b_clas(BlogModel bm)
        {
            string title = bm.title;
            string name = bm.name;
            string date = bm.date;
            string country = bm.country;
            string description = bm.description;

            if (bm.image != null && bm.image.Length > 0)
            {
                string filename = Path.GetFileName(bm.image.FileName);
                string fileuplod = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileuplod, FileMode.Create))
                {
                    await bm.image.CopyToAsync(str);
                }
                bm.insert(filename, title, name, date, country, description);
            }


            return View();
        }

        public IActionResult view_b_clas(BlogModel bm)
        {
            DataSet ds = bm.select();
            ViewBag.ds = ds.Tables[0];

            return View();
        }


        [HttpGet]
        public IActionResult delete_clas(BlogModel bm, int id)
        {
            bm.delete_clas(id);

            return RedirectToAction("view_b_clas");
        }

        [HttpGet]
        public IActionResult update_clas(BlogModel bm, int id)
        {
            DataSet ds = bm.update_clas(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> update_clas(BlogModel bm, int id, int a = 0)
        {
            string title = bm.title;
            string name = bm.name;
            string date = bm.date;
            string country = bm.country;
            string description = bm.description;

            var filename = "";

            if (bm.image != null && bm.image.Length > 0)
            {
                filename = Path.GetFileName(bm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await bm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            bm.update_clas(id, filename, title, name, date, country, description);

            return RedirectToAction("view_b_clas");
        }

		//bLOG Work Slider---------------------------------------------------------------------------------------------------------------------------------------


		[HttpGet]
		public IActionResult add_bw_slider()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_bw_slider(BlogSlider bs)
		{
			if (bs.image != null && bs.image.Length > 0)
			{
				string filename = Path.GetFileName(bs.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await bs.image.CopyToAsync(str);
				}

				bs.insert(filename);
			}


			return RedirectToAction("add_bw_slider");
		}

		public IActionResult view_bw_slider(BlogSlider bs)
		{
			DataSet ds = bs.select();
			ViewBag.ds = ds.Tables[0];
			return View();
		}

		public IActionResult delete_work(BlogSlider bs, int id)
		{
			bs.Delete(id);
			return RedirectToAction("view_bw_slider");
		}



		[HttpGet]
		public IActionResult update_blog_slider(BlogSlider bs, int id)
		{
			DataSet ds = bs.update(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_blog_slider(BlogSlider bs, int id, int a = 0)
		{

			var filename = "";

			if (bs.image != null && bs.image.Length > 0)
			{
				filename = Path.GetFileName(bs.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await bs.image.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}

			bs.update_data(id, filename);

			return RedirectToAction("view_bw_slider");
		}

		//Blog Single--------------------------------------------------------------------------------------------------------------------------------


		[HttpGet]
		public IActionResult add_bl_text()
		{
			return View();
		}

		[HttpPost]
		public IActionResult add_bl_text(BlogPost bp)
		{

			string title = bp.title;
			string name = bp.name;
			string date = bp.date;
			string cat = bp.cat;
			string discription1 = bp.discription1;
			string heading = bp.heading;
			string discription2 = bp.discription2;

			bp.insert(title, name, date, cat, discription1, heading, discription2);

			return RedirectToAction("add_bl_text");
		}

		public IActionResult view_bl_text(BlogPost bp)
		{
			DataSet ds = bp.select();
			ViewBag.ds = ds.Tables[0];

			return View();
		}

		public IActionResult delete_blog_text(BlogPost bp, int id)
		{
			bp.Delete(id);
			return RedirectToAction("view_bl_text");
		}

		[HttpGet]
		public IActionResult update_blog_text(BlogPost bp, int id)
		{
			DataSet ds = bp.update(id);
			ViewBag.ds = ds.Tables[0];
			return View();
		}

		[HttpPost]

		public IActionResult update_blog_text(BlogPost bp, int id, int a)
		{
			string title = bp.title;
			string name = bp.name;
			string date = bp.date;
			string cat = bp.cat;
			string discription1 = bp.discription1;
			string heading = bp.heading;
			string discription2 = bp.discription2;


			bp.update_data(id, title, name, date, cat, discription1, heading, discription2);
			return RedirectToAction("view_bl_text");
		}

		//Team--------------------------------------------------------------------------------------------------------------------------------------------


		[HttpGet]
		public IActionResult add_team()
		{
			return View();
		}

        [HttpPost]
        public async Task<ActionResult> add_team(TeamModel tm)
        {
            string name = tm.name;
            string post = tm.post;
            string discription = tm.discription;

            if (tm.image != null && tm.image.Length > 0)
            {
                string filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }

                tm.insert(name, post, discription, filename);
            }

            return RedirectToAction("add_team");
        }



        public IActionResult view_team(TeamModel tm)
        {
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }


        public IActionResult delete_t(TeamModel tm, int id)
        {
            tm.Delete(id);
            return RedirectToAction("view_team");
        }


        [HttpGet]
        public IActionResult update_team(TeamModel tm, int id)
        {
            DataSet ds = tm.update_team(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_team(TeamModel tm, int id, int a = 0)
        {
            string name = tm.name;
            string post = tm.post;
            string discription = tm.discription;


            var filename = "";

            if (tm.image != null && tm.image.Length > 0)
            {
                filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            tm.update_data(id, name, post, discription, filename);

            return RedirectToAction("view_team");
        }


        //Client--------------------------------------------------------------------------------------------------------------------------------------------



        [HttpGet]
        public IActionResult add_a_client()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_a_client(A_ClientModel cm)
        {
            if (cm.image != null && cm.image.Length > 0)
            {
                string filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }

                cm.insert(filename);
            }


            return RedirectToAction("add_a_client");
        }

        public IActionResult view_a_client(A_ClientModel cm)
        {
            DataSet ds = cm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }


        public IActionResult delete_a_cli(A_ClientModel cm, int id)
        {
            cm.Delete_a_cli(id);
            return RedirectToAction("view_a_client");
        }



        [HttpGet]
        public IActionResult update_a_cli(A_ClientModel cm, int id)
        {
            DataSet ds = cm.update_a_cli(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_a_cli(A_ClientModel cm, int id, int a = 0)
        {

            var filename = "";

            if (cm.image != null && cm.image.Length > 0)
            {
                filename = Path.GetFileName(cm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await cm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            cm.update_data(id, filename);

            return RedirectToAction("view_a_client");
        }


        //Three--------------------------------------------------------------------------------------------------------------------------------------------


        [HttpGet]
        public IActionResult add_three()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_three(ThreeModel tm)
        {
            string title = tm.title;
            string discription = tm.discription;



            if (tm.image != null && tm.image.Length > 0)
            {
                string filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }

                tm.insert(title, discription, filename);
            }


            return RedirectToAction("add_three");
        }

        public IActionResult view_three(ThreeModel tm)
        {
            DataSet ds = tm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }


        public IActionResult delete_three(ThreeModel tm, int id)
        {
            tm.Delete(id);
            return RedirectToAction("view_three");
        }



        [HttpGet]
        public IActionResult update_three(ThreeModel tm, int id)
        {
            DataSet ds = tm.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_three(ThreeModel tm, int id, int a = 0)
        {
            string title = tm.title;
            string discription = tm.discription;



            var filename = "";

            if (tm.image != null && tm.image.Length > 0)
            {
                filename = Path.GetFileName(tm.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await tm.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            tm.update_data(id, title, discription, filename);

            return RedirectToAction("view_three");
        }


		//Four--------------------------------------------------------------------------------------------------------------------------------------------


		[HttpGet]
		public IActionResult add_four()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_four(FourModel fm)
		{
			string title = fm.title;
			string discription = fm.discription;



			if (fm.image != null && fm.image.Length > 0)
			{
				string filename = Path.GetFileName(fm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await fm.image.CopyToAsync(str);
				}

				fm.insert(title, discription, filename);
			}


			return RedirectToAction("add_four");
		}

		public IActionResult view_four(FourModel fm)
		{
			DataSet ds = fm.select();
			ViewBag.ds = ds.Tables[0];

			return View();
		}


		public IActionResult delete_four(FourModel fm, int id)
		{
			fm.Delete(id);
			return RedirectToAction("view_four");
		}



		[HttpGet]
		public IActionResult update_four(FourModel fm, int id)
		{
			DataSet ds = fm.update(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_four(FourModel fm, int id, int a = 0)
		{
			string title = fm.title;
			string discription = fm.discription;



			var filename = "";

			if (fm.image != null && fm.image.Length > 0)
			{
				filename = Path.GetFileName(fm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await fm.image.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}

			fm.update_data(id, title, discription, filename);

			return RedirectToAction("view_four");
		}


		//Single--------------------------------------------------------------------------------------------------------------------------------------------


		[HttpGet]
		public IActionResult add_single()
		{
			return View();
		}

		[HttpPost]
		public async Task<ActionResult> add_single(SingleModel sm)
		{
			string title = sm.title;
			string discription = sm.discription;



			if (sm.image != null && sm.image.Length > 0)
			{
				string filename = Path.GetFileName(sm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await sm.image.CopyToAsync(str);
				}

				sm.insert(title, discription, filename);
			}


			return RedirectToAction("add_single");
		}

		public IActionResult view_single(SingleModel sm)
		{
			DataSet ds = sm.select();
			ViewBag.ds = ds.Tables[0];

			return View();
		}


		public IActionResult delete_single(SingleModel sm, int id)
		{
			sm.Delete(id);
			return RedirectToAction("view_single");
		}



		[HttpGet]
		public IActionResult update_single(SingleModel sm, int id)
		{
			DataSet ds = sm.update(id);
			ViewBag.ds = ds.Tables[0];

			foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
			{
				TempData["old_image_name"] = dr["image"].ToString();
			}

			return View();
		}



		[HttpPost]
		public async Task<ActionResult> update_single(SingleModel sm, int id, int a = 0)
		{
			string title = sm.title;
			string discription = sm.discription;

			var filename = "";

			if (sm.image != null && sm.image.Length > 0)
			{
				filename = Path.GetFileName(sm.image.FileName);
				string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
				using (var str = new FileStream(fileupload, FileMode.Create))
				{
					await sm.image.CopyToAsync(str);
				}
			}

			if (filename == "")
			{
				filename = TempData.Peek("old_image_name").ToString();
			}

			sm.update_data(id, title, discription, filename);

			return RedirectToAction("view_three");
		}


        //Single Work Text--------------------------------------------------------------------------------------------------------------------------------------------




        [HttpGet]
        public IActionResult add_sw_text()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_sw_text(WorkModel wm)
        {

            string title = wm.title;
            string name = wm.name;
            string date = wm.date;
            string cat = wm.cat;
            string discription1 = wm.discription1;
            string heading = wm.heading;
            string discription2 = wm.discription2;

            wm.insert(title, name, date, cat, discription1, heading, discription2);

            return RedirectToAction("add_sw_text");
        }

        public IActionResult view_sw_text(WorkModel wm)
        {
            DataSet ds = wm.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_work_text(WorkModel wm, int id)
        {
            wm.Delete(id);
            return RedirectToAction("view_sw_text");
        }

        [HttpGet]
        public IActionResult update_work_text(WorkModel wm, int id)
        {
            DataSet ds = wm.update(id);
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        [HttpPost]

        public IActionResult update_work_text(WorkModel wm, int id, int a)
        {
            string title = wm.title;
            string name = wm.name;
            string date = wm.date;
            string cat = wm.cat;
            string discription1 = wm.discription1;
            string heading = wm.heading;
            string discription2 = wm.discription2;


            wm.update_data(id, title, name, date, cat, discription1, heading, discription2);
            return RedirectToAction("view_sw_text");
        }


        //Single Work Slider---------------------------------------------------------------------------------------------------------------------------------------


        [HttpGet]
        public IActionResult add_sw_slider()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> add_sw_slider(SingleSlider ss)
        {
            if (ss.image != null && ss.image.Length > 0)
            {
                string filename = Path.GetFileName(ss.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);

                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await ss.image.CopyToAsync(str);
                }

                ss.insert(filename);
            }





            return RedirectToAction("add_sw_slider");
        }

        public IActionResult view_sw_slider(SingleSlider ss)
        {
            DataSet ds = ss.select();
            ViewBag.ds = ds.Tables[0];
            return View();
        }

        public IActionResult delete_work(SingleSlider ss, int id)
        {
            ss.Delete(id);
            return RedirectToAction("view_sw_slider");
        }



        [HttpGet]
        public IActionResult update_single_slider(SingleSlider ss, int id)
        {
            DataSet ds = ss.update(id);
            ViewBag.ds = ds.Tables[0];

            foreach (System.Data.DataRow dr in ViewBag.ds.Rows)
            {
                TempData["old_image_name"] = dr["image"].ToString();
            }

            return View();
        }



        [HttpPost]
        public async Task<ActionResult> update_single_slider(SingleSlider ss, int id, int a = 0)
        {

            var filename = "";

            if (ss.image != null && ss.image.Length > 0)
            {
                filename = Path.GetFileName(ss.image.FileName);
                string fileupload = Path.Combine(_environment.WebRootPath, "image", filename);
                using (var str = new FileStream(fileupload, FileMode.Create))
                {
                    await ss.image.CopyToAsync(str);
                }
            }

            if (filename == "")
            {
                filename = TempData.Peek("old_image_name").ToString();
            }

            ss.update_data(id, filename);

            return RedirectToAction("view_sw_slider");
        }


        //==========================================================================================================================================================




        public IActionResult Index()
		{
			return View();
		}

		//public IActionResult Deshboard1()
		//{
		//    return View();
		//}

		//public IActionResult Deshboard2()
		//{
		//    return View();
		//}

		//public IActionResult Deshboard3()
		//{
		//    return View();
		//}

		//public IActionResult widgets()
		//{
		//    return View();
		//}

		//public IActionResult chartjs()
		//{
		//    return View();
		//}

		//public IActionResult chartflot()
		//{
		//    return View();
		//}
		//public IActionResult chartinline()
		//{
		//    return View();
		//}

		//public IActionResult chartuplot()
		//{
		//    return View();
		//}

		//public IActionResult general()
		//{
		//    return View();
		//}

		//public IActionResult icons()
		//{
		//    return View();
		//}

		//public IActionResult buttons()
		//{
		//    return View();
		//}

		//public IActionResult sliders()
		//{
		//    return View();
		//}
		//public IActionResult modals()
		//{
		//    return View();
		//}

		//public IActionResult navbar()
		//{
		//    return View();
		//}

		//public IActionResult timeline()
		//{
		//    return View();
		//}
		//public IActionResult ribbons()
		//{
		//    return View();
		//}

		//public IActionResult formgeneral()
		//{
		//    return View();
		//}

		//public IActionResult advanced()
		//{
		//    return View();
		//}

		//public IActionResult editors()
		//{
		//    return View();
		//}
		//public IActionResult validation()
		//{
		//    return View();
		//}

		//public IActionResult simples()
		//{
		//    return View();
		//}

		//public IActionResult data()
		//{
		//    return View();
		//}
		//public IActionResult grid()
		//{
		//    return View();
		//}





	}  
 }

