using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeknikBilgi.Infrastructure.Constraints.Enums
{
    public enum Languages
    {
        [Description("Türkçe")]
        [Display(Name = "Turkish")]
        Turkish = 1,
        [Description("İngilizce")]
        [Display(Name = "English")]
        English = 2,
        [Description("Almanca")]
        [Display(Name = "Deutch")]
        Deutsch = 3
    }
}
