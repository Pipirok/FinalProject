//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            this.OrdersToServices = new HashSet<OrdersToService>();
        }
    
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerSurname { get; set; }
        public Nullable<int> LaundryWeight { get; set; }
        public Nullable<int> OrderStatus { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> TotalCost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrdersToService> OrdersToServices { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
    }
}