//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SK.HW16.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class Comment
    {
        public int Comment_UID { get; set; }
        public int Image_UID { get; set; }
        public System.DateTime TimeStamp { get; set; }
        public string CommentBody { get; set; }
    
        public virtual Image Image { get; set; }
    }
}
