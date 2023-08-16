using System.ComponentModel.DataAnnotations;

namespace VicStelmak.CIAA.WebUI.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string? Name { get; set; }
    }
}
