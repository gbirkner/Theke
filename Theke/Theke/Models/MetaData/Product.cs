using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Theke.Models.Product
{
    [MetadataType(typeof(ProductMetaData))]
    public partial class Product
    {

    }

    public class ProductMetaData
    {

        [Display(Name ="ProduktID")]
        public int ProductID { get; set; }

        [Display(Name = "Aktiv")]
        public Nullable<byte> IsActive { get; set; }

        [Required]
        [Display(Name = "Produktbezeichnung")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Das Feld mus mindesten 1 Zeichen enthalten")]
        public string Name { get; set; }

        [Display(Name = "Beschreibung")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Das Feld mus mindesten 1 Zeichen enthalten")]
        public string Note { get; set; }


        [Display(Name ="AltersfreigabeID")]
        public int AgeRatingID { get; set; }

        [Display(Name = "ProduktEinheitID")]
        public int ProductUnitID { get; set; }

        [Display(Name ="HerstellerID")]
        public int ProducerID { get; set; }


        [Display(Name = "Alkoholgehalt")]
        public int AlcoholAmount { get; set; }


        [Display(Name ="NährstoffGehaltID")]
        public int NutriantContentID { get; set; }

        [Display(Name ="Barcode")]
        public Nullable<int> EanNumber { get; set; }


        [Display(Name = "Pfand")]
        public int Deposit { get; set; }

        [Required]
        [Display(Name ="Füllmenge")]
        public int ItemAmount { get; set; }

        [Required]
        [Display(Name ="KategorieID")]
        public int CategorieID { get; set; }

        [Required]
        [Display(Name ="Min Preis")]
        public double MinPrice { get; set; }

        [Required]
        [Display(Name = "Max Preis")]
        public double MaxPricce { get; set; }


        [Required]
        [Display(Name = "Durchschnittlicher Einkaufspreis")]
        public Nullable<int> AveragePurchasePrice { get; set; }

        [Display(Name ="Erstellt von")]
        public string CreatedByID { get; set; }

        [Display(Name = "Geändert von")]
        public string ModifiedByID { get; set; }

        [Display(Name = "Erstellt am")]
        public System.DateTime CreatedDate { get; set; }

        [Display(Name = "Geändert am")]
        public System.DateTime ModfiedDate { get; set; }
    }
}