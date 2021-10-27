using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class Shipper
    {
        public int ShipperID { get; set; }

        [Required(ErrorMessage ="Bu alanın doldurulması zorunludur.")]
        [DisplayName("Şirket Adı")]
        [MaxLength(40, ErrorMessage ="En fazla 40 karakter girebilirsiniz.")]
        public string CompanyName { get; set; }

        [MaxLength(24, ErrorMessage = "Geçerli uzunlukta numara giriniz.")]
        [DisplayName("Telefon")]
        public string Phone { get; set; }
    }
}