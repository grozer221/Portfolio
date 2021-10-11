using System.ComponentModel.DataAnnotations;

namespace Portfolio.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Site link")]
        public string SiteLink { get; set; }
        [Display(Name = "Desktop app link")]
        public string DesktopAppLink { get; set; }
        [Display(Name = "Android app link")]
        public string AndroidAppLink { get; set; }
        [Display(Name = "IOS app link")]
        public string IOSAppLink { get; set; }
        public virtual UserModel User { get; set; }
    }
}
