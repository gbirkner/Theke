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
    
    public partial class NutriantContent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NutriantContent()
        {
            this.Product = new HashSet<Product>();
        }
    
        public int NutrinantContentID { get; set; }
        public Nullable<double> Energy { get; set; }
        public Nullable<double> Fat { get; set; }
        public Nullable<double> SutartedFat { get; set; }
        public Nullable<double> Carbohydrate { get; set; }
        public Nullable<double> Sugar { get; set; }
        public Nullable<double> Albumen { get; set; }
        public Nullable<double> Salt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product> Product { get; set; }
    }
}
