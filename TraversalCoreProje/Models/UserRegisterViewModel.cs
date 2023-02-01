using System.ComponentModel.DataAnnotations;

namespace TraversalCoreProje.Models
{
	public class UserRegisterViewModel
	{
		[Required(ErrorMessage ="lütfen adınızı giriniz")]
		public string Name { get; set; }

        [Required(ErrorMessage = "lütfen soyadınızı giriniz")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "lütfen kullanıcı adını giriniz")]
        public string Username { get; set; }

        [Required(ErrorMessage = "lütfen mail adresini giriniz")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "lütfen şifrenizi giriniz")]
        public string Password { get; set; }

        [Required(ErrorMessage = "lütfen şifreyi tekrar giriniz")]

        [Compare("Password",ErrorMessage ="şifreler uyumlu değil")]  // karşılaştırma attiribute ü
        public string ConfirmPassword { get; set; }
    }
}
