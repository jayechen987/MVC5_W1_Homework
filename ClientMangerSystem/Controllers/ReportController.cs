using ClientMangerSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientMangerSystem.Controllers
{
    public class ReportController : Controller
    {
        ClientEntities db = new ClientEntities();
        // GET: Report
        public ActionResult Index()
        {
            var list = db.vw_ClientDetail.ToList();
            return View(list);
        }
    }
}