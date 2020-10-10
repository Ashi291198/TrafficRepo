using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingSample.Entities;
using TrainingSample.Repository;

namespace TrainingSample.Controllers
{
    public class IndexController : Controller
    {
        IUserDetails userDetails = new UserDetailsRepository();
        // GET: Index
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var udetails = userDetails.GetUserDetails();
           
            PagedList<UserDetails> model = new PagedList<UserDetails>(udetails, page, pageSize);
           return View(model);
           // return View(udetails);
        }
        
        [HttpPost]
        public ActionResult InsertuS(UserDetails insert, string ProfilePic)
        {
            var t = ProfilePic.Substring(22);  // remove data:image/png;base64,

            byte[] bytes = Convert.FromBase64String(t);

            Image image;
            using (MemoryStream ms = new MemoryStream(bytes))
            { 
                image = Image.FromStream(ms);
            }
            var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
            var fullPath = Path.Combine(Server.MapPath("~/Content/Images/"), randomFileName);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            insert.ProfilePic = randomFileName;
            if (ModelState.IsValid)
            {
                userDetails.AddUserDetails(insert);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EdituS(int Id)
        {
           var v= userDetails.GetEditDetails(Id);

            // return View(v);
            return Json(new { UserId = v.UserId, FullName = v.FullName, UserEmail =v.UserEmail,  CarDetails = v.CarDetails }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult EdituS(ResultViewModel us)
        {
            userDetails.EditUserDetails(us);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteuS(int id)
        {

            userDetails.DeleteUserDetails(id);
            return RedirectToAction("Index");
        }

    }
}