using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace TestProject.WebApp.ViewModel
{
    public class ResponseRequestViewModel<T>
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public T ResponseData { get; set; }
    }

    public class ResponseViewModel
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }
    }
}