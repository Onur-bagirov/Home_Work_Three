using System.ComponentModel.DataAnnotations;
namespace EShopp.Web.Models.ViewModel
{
    public class ResgisterViewModel
    {
        [Required]
        public string UserEmail { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string UserPassword { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string UserName { get; set; }
    }
}
