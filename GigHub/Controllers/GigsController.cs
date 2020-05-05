using GigHub.Models;
using GigHub.ViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GigHub.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        //GigsController class eka call una gamanma eke constructor eka call wela ApplicationDbContext 
        //object ekak hadila,
        //    _context ekata assign wenawa.
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Gigs
        //Authorise attribute eka dammama authenticated user kenkta witharai create action eka 
        //access karana ahaki
        [Authorize]
        public ActionResult Create()
        {
            //me create kityala tyna eka naminma view eka tyenna ona Add a gig button eka click una gamanma 
            //me action ekata awilla me namama tyna view ekak mu hoyanawa e nisa me namama tyenna ona me view ekata
            //meken ena data thhama view eke preview karanne and view model ekata add wenne

            //View model eka create karala eke Genre properyt eka set karanna thama eka tyneh
            var viewModel = new GigFormViewModel
            {
                Genres = _context.Genres.ToList()
                //methanin karanne db eke tyna genres context eka haraha view model eke genres kiyana property ekata add
                //karana eka
            };
            return View(viewModel);
            //return eka athule me view model object eka yawanna ona view ekata
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GigFormViewModel viewModel)//methana gigfromviewmodel eken eke tyna hama property ekak ma construct wenawa
        {//reflection ekak tyna nisa hama property ekakma touch wnawa e nisa ehema property wenuwata method ekak dammama hari
            if (!ModelState.IsValid)
            {//methana create view ekata yanne aluth view model object ekak
                //e nisa genre tika ayema populate karaganna ona e nisa genre tika e initialize karannda ona
                viewModel.Genres = _context.Genres.ToList();
                return View("Create", viewModel);

                //return eke karanne create view ekata view model object eka pass karana eka
            }
                
            //create view ekata redirect karanawa,view model eke tyna data ekkama

            //var artistId = User.Identity.GetUserId();
            //var artist = _context.Users.Single(u => u.Id == artistId); meka dan ona wenne ne, artist id eka ganna 
            //property ekak model eke dala tynawa.eken kelinma id eka ganna thama tynne
            //var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var gig = new Gig
            {
                ArtistId = User.Identity.GetUserId(), //meka ganne asp.net wlama tyna login eken
                //DateTime = DateTime.Parse(String.Format("{0} {1}", viewModel.Date, viewModel.Time)), mekath view model eken 
                //ganna ona mokada eka class ekakin hari akarawa eka wadak karanna ona,e nisa view model ekenma date time gannona
                DateTime = viewModel.GetDateTime(),
                GenreId = viewModel.Genre,//meka ganne view model eken
                Venue = viewModel.Venue
            };

            _context.Gigs.Add(gig);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}