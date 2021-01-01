using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSosyalMedya.Models
{
    public class Otel
    {
        public int Id { get; set; }
        public int OtelYildizi { get; set; }
        public String OtelAdi { get; set; }
        public String SehirAdi { get; set; }
        public Sehir Sehir { get; set; }
        public String UlkeAdi { get; set; }
        public Ulke Ulke { get; set; }


    }
}
