using Demo.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class SavedList : BaseEntity
    {
        public Guid? UserId { get; set; }
        [Required]
        public User? User { get; set; }
        public ICollection<Post>? Posts { get; set; }
    }

}
