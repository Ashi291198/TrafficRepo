using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TrainingSample.Entities
{
    public class ResultViewModel
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string UserEmail { get; set; }
        public string PasswordHash { get; set; }
        public string CivilIdNumber { get; set; }
        public List<string> CarLicense
        {
            get; set;
        }

        public ResultViewModel()
        {
            CarLicense = new List<string>();
        }

        //public int UserId { get; set; }
        //public string FullName { get; set; }
        //public string UserEmail { get; set; }

        //public string CivilIdNumber { get; set; }
        //public string CarLicense { get; set; }
    }
}