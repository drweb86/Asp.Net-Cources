//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SK.CW.Dal
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int User_UID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Details_UID { get; set; }
    
        public virtual Detail Detail { get; set; }
    }
}
