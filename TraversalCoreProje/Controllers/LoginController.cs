using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TraversalCoreProje.Models;

namespace TraversalCoreProje.Controllers
{
    //altındaki bütün kod metot herşeyi erişilebilir yapıyor.. ileride autentication uygulayark bazı yerlere girişi engellicez ama buraya hep erişilecek
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult SignUp()  //kaydolma işlemi için kullanılacak signUp
        {

            return View();
        }

        [HttpPost]       
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)  //ben burada Identity e ait işlemler yapacaksam eğer tanımlayacagım metot async olmalı
        {
            AppUser appUser = new AppUser()
            {
                Name = p.Name,  //bunları textbox dan alıcaz
                Surname = p.Surname,
                Email=p.Mail,
                UserName=p.Username
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);  

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");  //aksiyona yönlendir dedik.. login sayfasına gidecek
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()  //login işlemi için kullanılacak
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(UserSıgnInViewModel p )  
        {
            if(ModelState.IsValid)  //eğer model geçerliyse
            {
                var result = await _signInManager.PasswordSignInAsync(p.Username, p.Password, false, true);  //false diyerek hatırlmasın dedik,true diyerek 5 defa yanlış girerse bloke et gibi
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Profile",new {area = "Member"}); //işlem doğruysa Profile içindeki index e yönlendir demek
                }
                else
                {
                    return RedirectToAction("SignIn", "Login");
                }
            }
            return View();
        }
    }
}
