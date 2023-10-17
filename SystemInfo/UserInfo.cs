using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KyoceraVIPackingSystem.SystemInfo
{
    public class UserInfo
    {

        private static PVSService.USERSEntity _user = null;
        public static bool Exist
        {
            get
            {
                return _user != null;
            }
        }
        public static string UserName
        {
            get
            {
                return _user.ID;
            }
        }
        public static string FullName
        {
            get { return _user.NAME; }
        }
        public static void CheckLogin(string userName, string password)
        {
            _user = Business.SingletonHelper.PVSInstance.CheckUserLogin(userName, password);
        }
    }
}
