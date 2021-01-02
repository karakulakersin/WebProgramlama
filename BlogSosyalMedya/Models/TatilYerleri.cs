using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSosyalMedya.Models
{
    public class TatilYerleri
    {
        public int Id { get; set; }
        public String YerAdı { get; set; }
        public String SehirId { get; set; }
        public Sehir Sehir { get; set;  }
        public String UlkeId { get; set; }
        public Ulke Ulke { get; set; }
        public String KategoriId { get; set; }
        public Kategori Kategori { get; set; }
        public int Puani { get; set; }
    }
}
