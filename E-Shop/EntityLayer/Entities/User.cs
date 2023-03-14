using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Entities
{
    public class User
    {
        // UserID
        // Name
        // Surname
        // Email
        // UserName
        // Password
        // RePassword
        // Role

        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage ="Boş Geçilmez")]
        [Display(Name="Ad")]
        [StringLength(50,ErrorMessage ="Max Karakter Sayısı")]
        public string Name { get; set; }


        [Required(ErrorMessage ="Boş Geçilmez")]
        [Display(Name="Soyad")]
        [StringLength(50,ErrorMessage ="Max Karakter Sayısı")]
        public string Surname { get; set; }


        //[Required(ErrorMessage = "Boş Geçilemez")]    //Maile şifre gönderimi sırasında Validation kontrolleri sıkıntı oluşturduğu için kapattım
        //[Display(Name = "E-Posta")]
        //[StringLength(50, ErrorMessage = "Max Karakter Sayısı")]
        //[EmailAddress(ErrorMessage = "E-Posta Formatında Giriş Yapınız")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Boş Geçilmez")]
        [Display(Name="Kullanıcı Adı")]
        [StringLength(50,ErrorMessage ="Max Karakter Sayısı")]
        public string UserName { get; set; }


        //[Required(ErrorMessage = "Boş Geçilmez")] 
        //[Display(Name = "Şifre")]
        //[StringLength(10, ErrorMessage = "Max Karakter Sayısı")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }


        //[Required(ErrorMessage = "Boş Geçilmez")]  
        //[Display(Name = "Şifre Tekrar")]
        //[StringLength(10, ErrorMessage = "Max Karakter Sayısı")]
        //[DataType(DataType.Password)]
        //[Compare("Password", ErrorMessage = "Şifreler Uyuşmuyor")]
        public string RePassword { get; set; }


        [Display(Name="Rol")]
        [StringLength(50,ErrorMessage ="Max Karakter Sayısı")]
        public string Role { get; set; }

    }
}
