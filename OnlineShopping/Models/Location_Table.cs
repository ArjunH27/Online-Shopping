//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Location_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Location_Table()
        {
            this.Service_Table = new HashSet<Service_Table>();
        }
    
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public int LocationPIN { get; set; }
        public string LocationDesc { get; set; }
        public string LocationCreatedBy { get; set; }
        public System.DateTime LocationCreatedDate { get; set; }
        public string LocationUpdatedBy { get; set; }
        public System.DateTime LocationUpdatedDate { get; set; }
        public bool LocationIsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service_Table> Service_Table { get; set; }
    }
}
