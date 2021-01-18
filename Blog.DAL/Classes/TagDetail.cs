using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.DAL.Classes
{
    public class TagDetail
    {
        [Key, Column(Order = 0)]
        public int TagID { get; set; }
        [Key, Column(Order = 1)]
        public int ProjectID { get; set; }

        //Mapping
        public virtual Tag Tag { get; set; }
        public virtual Project Project { get; set; }
    }
}
