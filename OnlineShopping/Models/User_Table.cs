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

    public partial class User_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User_Table()
        {
            this.Order_Table = new HashSet<Order_Table>();
            this.Product_Table = new HashSet<Product_Table>();
        }
    
        public int UserId { get; set; }
        public int Roleid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string UserAddress { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string UserCreatedBy { get; set; }
        public System.DateTime UserCreatedDate { get; set; }
        public Nullable<System.DateTime> UserUpdatedDate { get; set; }
        public bool UserIsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order_Table> Order_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Table> Product_Table { get; set; }
        public virtual Role_Table Role_Table { get; set; }
    }
}
