//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Technical_Test_Repository.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesMaster
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesMaster()
        {
            this.SalesDetails = new HashSet<SalesDetail>();
        }
    
        public int SalesMasterID { get; set; }
        public System.DateTime Date { get; set; }
        public int TotalQuantity { get; set; }
        public decimal TotalPrice { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
