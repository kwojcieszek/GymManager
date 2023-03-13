using GymManager.Common;

namespace GymManager.Models
{
    public class LoginModel
    {
        public bool Login(string userName, string password)
        {
            if (userName != null && password != null)
            {
                return new CurrentUser().Login(userName, password);
            }

            return false;
        }
    }
}