using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class PostDto
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageURL { get; set; }
        public string CategoryName { get; set; }
    }

}
