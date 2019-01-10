using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Auth;

namespace TestProject.Core.Interface
{
    public interface ILoginService
    {
        Account GetActiveTwitterUser();
    }
}
