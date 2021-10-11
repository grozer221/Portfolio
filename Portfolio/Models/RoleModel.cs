﻿using System.Collections.Generic;

namespace Portfolio.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual List<UserModel> Users { get; set; }
    }
}
