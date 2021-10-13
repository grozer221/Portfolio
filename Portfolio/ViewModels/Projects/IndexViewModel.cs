using Portfolio.Models.Projects;
using Portfolio.ViewModels.Common;
using System.Collections.Generic;

namespace Portfolio.ViewModels.Projects
{
    public class IndexViewModel
    {
        public IEnumerable<ProjectModel> Projects { get; set; }
        public PageViewModel Page { get; set; }
    }
}
