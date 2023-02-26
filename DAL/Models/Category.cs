using Demo.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Category : BaseEntity
    {
        public string Name { get; set; } = "";

        public ICollection<CategoryForPost>? CategoryForPost { get; set; }
  
    }

}
