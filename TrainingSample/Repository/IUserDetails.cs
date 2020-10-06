using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingSample.Entities;

namespace TrainingSample.Repository
{
    public interface IUserDetails
    {
        IEnumerable<UserDetails> GetUserDetails();
       
        void AddUserDetails(UserDetails insert);
        void DeleteUserDetails(int id);


       // IEnumerable<UserDetails> EditUserDetails(UserDetails delete);

    }
}
