﻿using System.Collections.Generic;

namespace Portfolio.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public virtual RoleModel Role { get; set; }
        public virtual List<ProjectModel> Projects { get; set; }
    }
}
