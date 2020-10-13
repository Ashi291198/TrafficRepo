using PagedList;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrainingSample.Entities;
using TrainingSample.EntityFramework;
using TrainingSample.Repository;

namespace TrainingSample.Controllers
{
    public class IndexController : Controller
    {
        IUserDetails userDetails = new UserDetailsRepository();
        // GET: Index
        //public ActionResult Index(int page = 1, int pageSize = 10)
        //{
        //    var udetails = userDetails.GetUserDetails();


        //    PagedList<UserDetails> model = new PagedList<UserDetails>(udetails, page, pageSize);
        //    return View(model);

        //}

        public ActionResult Index()
        {

            return View();
        }


        public JsonResult getdata()
        {


            using (var dbContext = new TraineeEntities())
            {

                List<UserDetail> USER = dbContext.UserDetails.ToList();
                List<CarDetail> Car = dbContext.CarDetails.ToList();
                List<GetViewModel> result = new List<GetViewModel>();

                foreach (var user in USER)
                {

                    var data = new GetViewModel
                    {

                        UserId = user.UserId,
                        FullName = user.FullName,
                        UserEmail = user.UserEmail,
                        Address = user.Address,


                    };

                    var cardetails = string.Join(",", Car.Where(x => x.UserId == user.UserId).Select(y => y.CarLicense).ToList());

                    data.CarLicense = cardetails;


                    result.Add(data);

                }
                // result = result.Where(x => x.CarLicense != "").ToList();

                return Json(new { data = result }, JsonRequestBehavior.AllowGet);

            }
        }


        
        [HttpPost]
        public ActionResult InsertuS(UserDetails insert, string ProfilePic)
        {
           // var t = ProfilePic.Substring(22);  // remove data:image/png;base64,
            string t = ProfilePic.Substring(ProfilePic.IndexOf(',') + 1);


            byte[] bytes = Convert.FromBase64String(t);

            Image image;
            using (var ms = new MemoryStream(bytes,0,bytes.Length))
            { 
                image = Image.FromStream(ms,true);
            }
            var randomFileName = Guid.NewGuid().ToString().Substring(0, 4) + ".png";
            var fullPath = Path.Combine(Server.MapPath("~/Content/Images/"), randomFileName);
            image.Save(fullPath, System.Drawing.Imaging.ImageFormat.Png);
            insert.ProfilePic = randomFileName;
            if (ModelState.IsValid)
            {
                userDetails.AddUserDetails(insert);
            }

           
            return Json(new { data = true });
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
            return Json(new { data = true });
            //return RedirectToAction("Index");
        }
        public ActionResult DeleteuS(int? id)
        {

            userDetails.DeleteUserDetails(id);
            return RedirectToAction("Index");
        }

    }
}