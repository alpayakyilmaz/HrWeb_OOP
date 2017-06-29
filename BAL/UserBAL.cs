using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;
using DAL;

namespace BAL
{
    public class UserBAL
    {
        public int Validate(string userName, string password)
        {

            User user = new User();
            user.UserName = userName;
            user.Password = password;

            return this.Validate(user);
        }

        public int Validate(User user)
        {
            UserDAL uDAL = new UserDAL();
            try
            {
                return uDAL.ValidateUser(user);
            }
            catch (Exception)
            {
                
                throw;
            }

            finally
            {
                uDAL.Dispose();
            }
        }

    }
}
