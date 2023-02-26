using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Demo.Models.Base;

namespace DAL.Models
{
    public class CategoryForPost
    {
        public Guid CategoryId { get; set; }
        public Category? Category { get; set; }

        public Guid PostId { get; set; }
        public Post? Post { get; set; }
    }
}
