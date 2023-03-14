using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Product
    {
        // ID
        // Name
        // Description
        // Price
        // Stock
        // Populer
        // IsApproved
        // Image

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage="Boş Geçilemez")]
        [Display(Name="Ad")]
        [StringLength(50,ErrorMessage="Max Karakter Sayısı")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        [Display(Name="Açıklama")]
        [StringLength(200,ErrorMessage ="Max Karakter Sayısı")]
        public string Description { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        [Display(Name="Fiyat")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Boş Geçilemez")]
        [Display(Name = "Stok")]
        public int Stock { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        public bool Populer { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        [Display(Name="Onaylandı")]
        public bool IsApproved { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        [Display(Name="Resim")]
        public string Image { get; set; }


        [Required(ErrorMessage ="Boş Geçilemez")]
        [Display(Name="Kategori")]
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }
        //Bir ürün bir kategoride bulunur

        public virtual List<Cart>Cart { get; set; }
        //Sepette birden ço ürün bulunabilir.

        public virtual List<Sale>Sale { get; set; }
        //Birden fazla ürün satın alınabilir.

    }
}
