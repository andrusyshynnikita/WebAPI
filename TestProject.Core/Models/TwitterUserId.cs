using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.Models
{
    public class TwitterUserId
    {
        private static long _id_user;

        public static long Id_User
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
