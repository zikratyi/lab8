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
    
    public partial class Client_firm
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Client_firm()
        {
            this.Request = new HashSet<Request>();
        }
    
        public int ID_firm { get; set; }
        public string name_firm { get; set; }
        public Nullable<int> personal_info_confidant { get; set; }
        public string VAT { get; set; }
        public Nullable<int> address_firm { get; set; }
    
        public virtual Address Address { get; set; }
        public virtual Personal_info Personal_info { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Request> Request { get; set; }
    }
}
