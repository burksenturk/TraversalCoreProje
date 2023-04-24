using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TraversalCoreProje.Areas.Admin.Models;

namespace TraversalCoreProje.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;

        public AnnouncementController(IAnnouncementService announcementService)
        {
            _announcementService = announcementService;
        }

        public IActionResult Index()
        {
            List<Announcement> announcements = _announcementService.TGetList();
            List<AnnouncementViewModel> model = new List<AnnouncementViewModel>();
            foreach (var item in announcements)
            {
                AnnouncementViewModel model1 = new AnnouncementViewModel();
                model1.Title = item.Title;
                model1.ID = item.AnnouncementID;
                model1.Content = item.Content;

                model.Add(model1);
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddAnnouncement(string t) 
        {
            return View(t);
        }
    }
}
