using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DesignPatternSampleProject.Controllers
{
    public class BaseController : Controller
    {
       public UnitOfWork _UOW;

        public BaseController()
        {
            _UOW = new UnitOfWork();
        }

       
    }
}