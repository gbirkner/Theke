//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Theke.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderPosition
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public OrderPosition()
        {
            this.BarOrders = new HashSet<BarOrder>();
        }
    
        public int OrderPositionID { get; set; }
        public int PriceHistoryID { get; set; }
        public int Amount { get; set; }
    
        public virtual PriceHistory PriceHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BarOrder> BarOrders { get; set; }
    }
}
