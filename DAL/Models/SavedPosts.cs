using Demo.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SavedPost : BaseEntity
    {
        public Guid PostId { get; set; }
        public Guid UserId { get; set; }
        public Post? Post { get; set; }
        public User? User { get; set; }
    }
}
