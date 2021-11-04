using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Portfolio.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual int RoleId { get; set; }
        public virtual RoleModel Role { get; set; }
        public virtual List<ProjectModel> Projects { get; set; }
        public virtual List<TechnologyModel> Technologies { get; set; }
        public virtual List<LikeModel> Likes { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
