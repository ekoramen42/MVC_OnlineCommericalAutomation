using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_OnlineCommericalAutomation.Models.Sınıflar
{
    public class Kategori
    {
        [Key]
        public int KategoriID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string KategoriAD { get; set; }
        public ICollection<Urun> Uruns { get; set; }
    }
}