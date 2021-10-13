using Portfolio.Models;
using System.Collections.Generic;

namespace Portfolio.ViewModels
{
    public class ProjectsIndexViewModel
    {
        public List<ProjectModel> Projects { get; set; }
        public PageViewModel Page { get; set; }
    }
}
