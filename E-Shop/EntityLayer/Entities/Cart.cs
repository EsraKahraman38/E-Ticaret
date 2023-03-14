using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class Cart
    {
        // ID
        // UrunID
        // Quantity
        // Price
        // Date
        // Image

        [Key]
        public int Id { get; set; }


        [Display(Name ="Ürün")]
        public int ProductID { get; set; }
        public virtual Product Product { get; set; }


        [Display(Name ="Miktar")]
        public int Quantity { get; set; }


        [Display(Name ="Fiyat")]
        public decimal Price { get; set; }


        [Display(Name ="Tarih")]
        public DateTime Date { get; set; }


        [Display(Name ="Resim")]
        public int Image { get; set; }


        [Display(Name ="Kullanıcı")]
        public int UserID { get; set; }

    }
}
