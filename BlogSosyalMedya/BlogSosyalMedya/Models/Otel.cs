using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSosyalMedya.Models
{
    public class Otel
    {
        public int Id { get; set; }
        public String OtelAdi { get; set; }
        public int OtelYildizi { get; set; }
        public int SehirId { get; set; }
        public Sehir Sehir { get; set; }
        public int UlkeId { get; set; }
        public Ulke Ulke { get; set; }
        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
