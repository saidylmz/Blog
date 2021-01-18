using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Classes
{
    public class Project
    {
        public int ID { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Column(TypeName="Image")]
        public byte[] Image { get; set; }

        //Mapping
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<TagDetail> TagDetails { get; set; }
    }
}
