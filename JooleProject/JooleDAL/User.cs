//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JooleDAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public int User_ID { get; set; }
        public string User_Name { get; set; }
        public string User_Email { get; set; }
        public string User_Image { get; set; }
        public string User_Password { get; set; }
        public int Credential_ID { get; set; }
    
        public virtual Credential Credential { get; set; }
    }
}
