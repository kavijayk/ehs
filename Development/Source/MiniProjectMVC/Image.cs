//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniProjectMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Image
    {
        public int ImageId { get; set; }
        public int PropertyId { get; set; }
        public string Image1 { get; set; }
    
        public virtual Property Property { get; set; }
    }
}
