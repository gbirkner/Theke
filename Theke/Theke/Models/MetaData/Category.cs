using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Theke.Models.MetaData {

    [MetadataType( typeof( CategoryMetaData ) )]
    public partial class Category {
    }



    public class CategoryMetaData {

        [Required]
        [Display(Name = "Kategorie")]
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Das Feld mus mindesten 1 Zeichen enthalten")]
        public string Name { get; set; }


        [Display(Name = "ShortName")]
        [StringLength(10, ErrorMessage = "Hier können maximal 10 Zeichen eingegeben werden!")]
        public string SName { get; set; }

    }
}
