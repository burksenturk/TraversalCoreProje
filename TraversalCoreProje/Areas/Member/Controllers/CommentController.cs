using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProje.Areas.Member.Controllers
{
    [Area("Member")]  //sayfanın açılabilmesi için yaptık
    [AllowAnonymous]
    public class CommentController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}
