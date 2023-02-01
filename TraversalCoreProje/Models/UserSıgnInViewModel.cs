using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
    public class UserSıgnInViewModel
    {
        [Required(ErrorMessage ="Lütfen kullanıcı adını giriniz")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen şifrenizi giriniz")]
        public string Password { get; set; }
    }
}
