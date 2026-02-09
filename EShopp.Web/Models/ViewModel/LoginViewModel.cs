using System.ComponentModel.DataAnnotations;
namespace EShopp.Web.Views.ViewModel
{
    public class LoginViewModel
    {        
        [Required]
        public string UserName { get; set; }

        [Required]
        public string UserPassword { get; set; }

        [Display]
        public bool RememberMe { get; set; }
    }
}
