using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Theke.Models;

namespace Theke.Controllers.OrderView
{
    public class BarTablesController : Controller
    {
        // GET: BarTables
        public ActionResult Index()
        {
            return View();
        }
    }

    
}