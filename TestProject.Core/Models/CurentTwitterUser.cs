using System;
using System.Collections.Generic;
using System.Text;

namespace TestProject.Core.Models
{
    class CurentTwitterUser
    {
        public int CurentUserId { get; set; }

        public CurentTwitterUser(int curentUserId)
        {
            CurentUserId = curentUserId;
        }

        public CurentTwitterUser()
        {

        }
    }
}
