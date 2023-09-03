using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Demo.Models.Base;
using System.Text.Json.Serialization;

namespace DAL.Models
{
    public class CategoryForPost
    {
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }
        [JsonIgnore]
        public Guid PostId { get; set; }
        public Post? Post { get; set; }
    }
}
