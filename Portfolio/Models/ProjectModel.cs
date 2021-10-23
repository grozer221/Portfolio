using Microsoft.AspNetCore.Http;
using Portfolio.Attributes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class ProjectModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Project must have name")]
        [MinLength(2, ErrorMessage = "Project must have lenght longer then 2")]
        public string Name { get; set; }

        [Display(Name = "Image")]
        public string ImageURL { get; set; }

        public string Description { get; set; }

        [Display(Name = "Site link")]
        public string SiteLink { get; set; }

        [Display(Name = "Desktop app link")]
        public string DesktopAppLink { get; set; }

        [Display(Name = "Android app link")]
        public string AndroidAppLink { get; set; }

        [Display(Name = "IOS app link")]
        public string IOSAppLink { get; set; }

        public virtual UserModel CreatedByUser { get; set; }

        public virtual List<TechnologyModel> Technologies { get; set; }

        [NotMapped]
        public int[] TechnologiesIds { get; set; }

        public virtual List<LikeModel> Likes { get; set; }
        public virtual List<CommentModel> Comments { get; set; }

        [NotMapped]
        [FileExtension]
        public IFormFile ImageUpload { get; set; }
    }
}
