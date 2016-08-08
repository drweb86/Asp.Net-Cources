using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK.HW16.ViewModels
{
    public class CommentViewModel
    {
        public int Comment_UID { get; set; }
        public int Image_UID { get; set; }
        public string CommentBody { get; set; }
        public System.DateTime TimeStamp { get; set; }
    }
}
