using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ActivityMVC.Models
{
    public class Activity
    {
        [Key]
        public int ActivityID { get; set; }

        [DisplayName("Etkinlik Adı")]
        [Required(ErrorMessage = "Etkinlik Adını giriniz.")]
        public string ActivityName { get; set; }
        
        [DisplayName("Başlama Tarihi")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage ="Başlama Tarihini giriniz.")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }

        [DisplayName("Bitiş Tarihi")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? FinishDate{ get; set; }

        [DisplayName("Etkinlik Yeri")]
        [Required(ErrorMessage = "Etkinlik yerini giriniz.")]
        public string Location { get; set; }

        [DisplayName("Etkinlik Ücreti")]
        public string Price { get; set; }

        [DisplayName("Kişi Sayısı")]
        public int MaxPerson { get; set; }

        [DisplayName("Açıklama")]
        [MaxLength(100)] // db tarafı için
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Açıklama 3-500 karakter arası olmalı")]
        [Column(TypeName = "text")]
        public string Aciklama { get; set; }

        [DisplayName("Resim Ekle")]
        [DataType(DataType.Upload)]
        public string PictureName { get; set; }

        //Mapping 
        public virtual Category Category { get; set; }
        public virtual User  User { get; set; }
        public virtual List<Service> Services { get; set; }
        public virtual List<Member> Members { get; set; }

    }
}