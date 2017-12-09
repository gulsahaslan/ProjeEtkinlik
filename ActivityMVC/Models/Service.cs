using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivityMVC.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }


        [DisplayName("Servis Kalkış Zamanı")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Kalkış Tarihini giriniz.")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }


        [DisplayName("Servis Dönüş Zamanı")]
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Dönüş Tarihini giriniz.")]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FinishDate { get; set; }


        [DisplayName("Servis Kalkış Yeri")]
        [Required(ErrorMessage = "Servis kalkış yerini giriniz.")]
        public string StartLocation { get; set; }


        [DisplayName("Servis Dönüş Yeri")]
        [Required(ErrorMessage = "Servis dönüş yerini giriniz.")]
        public string FinishLocation { get; set; }


        [DisplayName("Servis Kişi Kapasitesi")]
        public int Capacity { get; set; }


        [DisplayName("Servis Ücreti")]
        public string Price { get; set; }

        //Mapping
        public virtual Activity Activity { get; set; }
    }
}