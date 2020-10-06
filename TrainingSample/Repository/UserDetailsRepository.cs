using PagedList;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using TrainingSample.Entities;
using TrainingSample.EntityFramework;

namespace TrainingSample.Repository
{
    public class UserDetailsRepository : IUserDetails
    {
        public IEnumerable<UserDetails> GetUserDetails()
        {
            //UserDetails udetailsData = new UserDetails();
            using (var dbContext = new TraineeEntities())
            {

                List<UserDetail> USER = dbContext.UserDetails.ToList();
                List<CarDetail> Car = dbContext.CarDetails.ToList();
                List<UserDetails> result = new List<UserDetails>();

                foreach (var user in USER)
                {

                    var data = new UserDetails
                    {

                        UserId = user.UserId,
                        FullName = user.FullName,
                        UserEmail = user.UserEmail,
                        CivilIdNumber = user.CivilIdNumber,


                    };

                    var cardetails = string.Join(",", Car.Where(x => x.UserId == user.UserId).Select(y => y.CarLicense).ToList());

                    data.CarLicense = cardetails;


                    result.Add(data);

                }

                return result;

            }
        }


        public void AddUserDetails(UserDetails insert)
        {

            using (var dbContext = new TraineeEntities())
            {
               
                //string FileName = Path.GetFileNameWithoutExtension(insert.ImageFile.FileName);


                //string FileExtension = Path.GetExtension(insert.ImageFile.FileName);
                //FileName = DateTime.Now.ToString("yyyyMMdd") + "-" + FileName.Trim() + FileExtension;

                //string UploadPath = ConfigurationManager.AppSettings["UserProfilePic"].ToString();
                //insert.ProfilePic = UploadPath + FileName;
                //insert.ImageFile.SaveAs(insert.ProfilePic);
                var user = new UserDetail()
                {
                    FullName = insert.FullName,
                    UserEmail = insert.UserEmail,
                    PasswordHash = insert.PasswordHash,
                    CivilIdNumber = insert.CivilIdNumber,

                    DOB = insert.DOB,
                    MobileNo = insert.MobileNo,
                    Address = insert.Address,
                    RoleId = insert.RoleId,
                    ProfilePic =insert.ProfilePic,


                    CreatedDate = insert.CreatedDate,
                    ModifiedDate = insert.ModifiedDate,
                    IsNotificationActive = insert.IsNotificationActive,
                    IsActive = insert.IsActive,
                    DeviceId = insert.DeviceId,
                    DeviceType = insert.DeviceType,
                    FcmToken = insert.FcmToken,
                    verify = insert.verify,
                    VerifiedBy = insert.VerifiedBy,
                    Area = insert.Area,
                    Block = insert.Block,
                    Street = insert.Street,
                    Housing = insert.Housing,
                    Floor = insert.Floor,
                    NewPass = insert.NewPass,
                    ConPass = insert.ConPass,
                    Jadda = insert.Jadda,
                    Reason = insert.Reason,
                    ActivatedBy = insert.ActivatedBy,
                    ActivatedDate = insert.ActivatedDate


                };

                var car = new CarDetail()
                {
                    UserId = insert.UserId,
                    CarLicense = insert.CarLicense

                };


                dbContext.UserDetails.Add(user);
                dbContext.CarDetails.Add(car);
                dbContext.SaveChanges();


            }
        }


        public void DeleteUserDetails(int id)
        {
            using (var dbContext = new TraineeEntities())
            {
                var user = dbContext.UserDetails.Where(u => u.UserId == id).FirstOrDefault();
                var car = dbContext.CarDetails.Where(c => c.UserId == id).ToList();

                user.IsActive = false;
                dbContext.Entry(user).State = EntityState.Modified;
                // CarDetail car = db.CarDetails.Find(id);
                if (car.Count() > 0)
                {
                    dbContext.CarDetails.RemoveRange(car);
                }

                dbContext.SaveChanges();
            }
        }


        //public IEnumerable<UserDetails> EditUserDetails(int? id)
        //{
        //    using (var dbContext = new TraineeEntities())
        //    {

        //        var viewModel = (from a in dbContext.UserDetails

        //                         where a.UserId == id
        //                         select new Entities.UserDetails
        //                         {
        //                             // UserId = a.UserId,
        //                             FullName = a.FullName,
        //                             UserEmail = a.UserEmail,
        //                             Address = a.Address,
        //                             ProfilePic = a.ProfilePic
        //                             //CivilIdNumber = a.CivilIdNumber
        //                         }).FirstOrDefault();
        //        var cars = dbContext.CarDetails.Where(x => x.UserId == id).Select(y => y.CarLicense).ToList();

        //         viewModel.CarLicense.AddRange(cars);

        //        return viewModel;
        //    }
        //}
    }
}
        
    
