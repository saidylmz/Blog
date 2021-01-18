using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Classes
{
    public class Tag
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Mapping
        public virtual ICollection<TagDetail> TagDetails { get; set; }
    }
}
