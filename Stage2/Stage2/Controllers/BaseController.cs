using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Stage2.Controllers
{
    public class BaseController : Controller
    {
        public DesignPatternSampleEntities db;

        public BaseController()
        {
            db = new DesignPatternSampleEntities();
        }
    }
}