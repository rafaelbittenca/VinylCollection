using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vinyl.DAL.Contract;

namespace Vinyl.UI.Controllers
{
    public class RecordController : Controller
    {

        // Working on it

        //private readonly IUnitOfWork _unitOfWork;
        //public RecordController(IUnitOfWork unitOfWork)
        //{
        //    _unitOfWork = unitOfWork;
        //}

        //public ActionResult FullAccess()
        //{
        //    ViewBag.ReadOnly = "NO";
        //    return View("Index");
        //}

        // GET: Record
        public ActionResult Index()
        {
            //ViewBag.ReadOnly = "YES";
            return View();
        }
    }
}