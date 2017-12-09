using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ActivityMVC.Models
{
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }
        [DisplayName("Kategori Adı")]
        public string CategoryName { get; set; }

        //Mapping
        public virtual List<Activity> Activities { get; set; }
    }
}