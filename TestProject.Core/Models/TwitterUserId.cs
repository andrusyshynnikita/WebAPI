using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.Models
{
    public class TwitterUserId
    {
        private static string _id_user;

        public static string Id_User
        {
            get
            {
                return _id_user;
            }

            set
            {
                _id_user = value;
            }
        }
    }
}
