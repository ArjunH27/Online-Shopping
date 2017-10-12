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
    
    public partial class Product_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product_Table()
        {
            this.Image_Table = new HashSet<Image_Table>();
            this.OrderDetail_Table = new HashSet<OrderDetail_Table>();
            this.Service_Table = new HashSet<Service_Table>();
        }
    
        public int ProductId { get; set; }
        public int ProductCatid { get; set; }
        public int SellerId { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductDesc { get; set; }
        public int ProductStock { get; set; }
        public string ProductCreatedBy { get; set; }
        public System.DateTime ProductCreatedDate { get; set; }
        public string ProductUpdatedBy { get; set; }
        public System.DateTime ProductUpdatedDate { get; set; }
        public bool ProductIsDeleted { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Image_Table> Image_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderDetail_Table> OrderDetail_Table { get; set; }
        public virtual ProductCategory_Table ProductCategory_Table { get; set; }
        public virtual User_Table User_Table { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Service_Table> Service_Table { get; set; }
    }
}
