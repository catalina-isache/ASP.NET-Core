using Demo.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class User : BaseEntity
    {
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";
        public SavedList? SavedList { get; set; }
        public ICollection<SavedPost>? SavedPosts { get; set; }

        public Role? Role { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; } = "";
    }

}
