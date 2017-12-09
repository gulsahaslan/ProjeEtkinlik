using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivityMVC.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }

        [DisplayName("Ad")]
        [Required(ErrorMessage ="Lütfen adınızını girin")]
        public string FirstName { get; set; }


        [DisplayName("Soyad")]
        [Required(ErrorMessage ="Lütfen soyadınızı girin")]
        public string LastName { get; set; }


        [DisplayName("Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adınızı girin")]
        public string Username { get; set; }

        [DisplayName("Şifre")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage ="Şifrenizi girin")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Açıklama 3-500 karakter arası olmalı")]
        public string Password { get; set; }


        [DisplayName("Şifre")]
        [Required(ErrorMessage = "Şifreyi tekrar giriniz")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifre ve tekrar aynı değil")]
        public string ConfirmPassword { get; set; }

        [DisplayName("Mail Adresi")]
        [Required(ErrorMessage ="Mail adresi giriniz.")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Geçerli bir e-posta giriniz.")]
        public string Email { get; set; }

        [DisplayName("Telefon No")]
        [Required(ErrorMessage ="Telefon numaranızı giriniz.")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(10, ErrorMessage ="Lütfen 10 karakter giriniz.")]
        public string Phone { get; set; }

        [DisplayName("Meslek")]
        public string Job { get; set; }

        [DisplayName("Cinsiyet")]
        [Required(ErrorMessage ="Cinsiyetinizi seçiniz.")]
        public bool Gender { get; set; }

        //Mapping
        public virtual List<Activity> Activities { get; set; }
    }
}