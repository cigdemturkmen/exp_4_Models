using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace exp_4_Models.Models
{
    public class Product
    {
        public int ProductID { get; set; }

        [Required(ErrorMessage = "Bu alanın doldurulması zorunludur!")]
        [DisplayName("Ürün Adı")]
        public string ProductName { get; set; }

        [DisplayName("Birim Fiyat")]
        public decimal UnitPrice { get; set; }

        [DisplayName("Stok Miktarı")]
        public short UnitsInStock { get; set; }

        [DisplayName("Kategori Id/Adı?")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}