using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Category
    {
        // ID
        // Name
        // Description

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        [Display(Name="Ad")]
        [StringLength(50,ErrorMessage ="Max Karakter Sayısı")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        [Display(Name ="Açıklama")]
        [StringLength(200,ErrorMessage ="Max Karakter Sayısı")]
        public string Description { get; set; }


        public virtual List<Product>Products { get; set; }
        //Bir kategoride birden fazla ürün olabilir
    }
}
