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
    
    public partial class PriceHistory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PriceHistory()
        {
            this.OrderPositions = new HashSet<OrderPosition>();
        }
    
        public int PriceHistoryID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public double Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderPosition> OrderPositions { get; set; }
        public virtual Product Product { get; set; }
    }
}
