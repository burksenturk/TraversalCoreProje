﻿using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());

        ReservationManager reservationManager = new ReservationManager(new EfReservationDal());

        private readonly UserManager<AppUser> _userManager; //Autantice olan kullanıcının Appuser id sine ulasmak için ekledim. 

        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult MyCurrentReservation()
        {
            return View();
        }
        public IActionResult MyOldReservation()
        {
            return View();
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListApprovalReservation(values.Id);
            return View(valueslist);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            //destination bilgisini dropdown dan alıcaz
            List<SelectListItem> values = (from x in destinationManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.DestinationID.ToString() // kullanmıcaz ama..
                                           }).ToList();
            ViewBag.v=values;
            return View();
        }
        [HttpPost]
        public IActionResult NewReservation(Reservation p)
        {
            p.AppUserId = 3;  //şimdilik static yaptım
            p.Status = "Onay bekliyor.";
            reservationManager.TAdd(p);
            return RedirectToAction("MyCurrentReservation");  //aktif rezervasyonlarıma yönlendirecek
        }
    }
}
