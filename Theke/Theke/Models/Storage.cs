
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
    
public partial class Storage
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Storage()
    {

        this.DeliverySlip = new HashSet<DeliverySlip>();

    }


    public int StorageID { get; set; }

    public int ProductID { get; set; }

    public int Amount { get; set; }

    public System.DateTime ExpirationDate { get; set; }



    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<DeliverySlip> DeliverySlip { get; set; }

    public virtual Product Product { get; set; }

}

}
