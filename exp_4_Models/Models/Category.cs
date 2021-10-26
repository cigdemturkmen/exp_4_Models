using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class Category
    {
        public int CategoryID { get; set; }

        [DisplayName("Kategori Adı")]
        [Required(ErrorMessage ="Bu alan zorunludur.")]
        [StringLength(15, ErrorMessage ="En fazla 15 karakter girilebilir")]
        public string CategoryName { get; set; }

        [DisplayName("Kategori Açıklaması")]
        public string Description { get; set; }
    }
}