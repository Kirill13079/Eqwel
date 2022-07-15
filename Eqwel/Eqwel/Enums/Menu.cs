using System.ComponentModel.DataAnnotations;

namespace Eqwel.Enums
{
    public enum Menu
    {
        [Display(Name = "Statistics")]
        Statistics,
        [Display(Name = "Options")]
        Option,
        [Display(Name = "Setting")]
        Setting
    }
}
