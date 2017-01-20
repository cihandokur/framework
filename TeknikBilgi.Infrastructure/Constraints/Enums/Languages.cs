using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TeknikBilgi.Infrastructure.Constraints.Enums
{
    public enum Languages
    {
        [Description("Türkçe")]
        [Display(Name = "NP.Admin.Languages.Turkish")]
        Turkish = 1,
        [Description("İngilizce")]
        [Display(Name = "NP.Admin.Languages.English")]
        English = 2,
        [Description("Almanca")]
        [Display(Name = "NP.Admin.Languages.Deutch")]
        Deutsch = 3
    }
}
