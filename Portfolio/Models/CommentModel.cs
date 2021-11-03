using System;

namespace Portfolio.Models
{
    public class CommentModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreate { get; set; }
        public virtual int UserId { get; set; }
        public virtual UserModel User { get; set; }
        public virtual int ProjectId { get; set; }
        public virtual ProjectModel Project{ get; set; }
    }
}
