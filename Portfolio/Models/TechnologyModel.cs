using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class TechnologyModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Project must have name")]
        [MinLength(1, ErrorMessage = "Project must have lenght longer then 1")]
        public string Name { get; set; }
        [Display(Name = "Date create")]
        public DateTime DateCreate { get; set; }
        [Display(Name = "Date last change")]
        public DateTime DateLastChange { get; set; }
        public virtual List<ProjectModel> Projects { get; set; }
        public virtual UserModel CreatedByUser { get; set; }
        [NotMapped]
        public bool Selected { get; set; }
    }
}
