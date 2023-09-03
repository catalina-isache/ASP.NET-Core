using Demo.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Post : BaseEntity
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public string ImageURL { get; set; } = "";
        [JsonIgnore]
        public ICollection<CategoryForPost>? CategoryForPost { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<SavedPost>? SavedPosts { get; set; }
        public User? User { get; set; }
        public Guid? UserId { get; set; }
    }
}
