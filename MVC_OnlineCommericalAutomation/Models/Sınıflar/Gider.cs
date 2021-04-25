using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVC_OnlineCommericalAutomation.Models.Sınıflar
{
    public class Gider
    {
        [Key]
        public int Giderid { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(100)]
        public string Acıklama { get; set; }
        public DateTime Tarih { get; set; }
        public decimal Tutar { get; set; }
    }
}