using GigHub.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();

            //MemberAccessException class ela call wenakotama _context ekata database eka load karagannawa
            //itapasse _context eken ona wadak karaganna pluwan database eke tyna data sambandawa.
        }

        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                               .Include(g=>g.Artist)
                               .Where(g => g.DateTime > DateTime.Now);

            //usersla wenama ganna hati ganath balanna 

            return View(upcomingGigs);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}