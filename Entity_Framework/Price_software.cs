//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Entity_Framework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Price_software
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Price_software()
        {
            this.Request = new HashSet<Request>();
        }
    
        public int article { get; set; }
        public int software { get; set; }
        public double regular_price { get; set; }
        public string discount { get; set; }
        public Nullable<double> action_price { get; set; }
        public string note_action { get; set; }
        public string item { get; set; }
    
        public virtual List_software List_software { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request { get; set; }
    }
}
