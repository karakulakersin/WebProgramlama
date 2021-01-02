using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSosyalMedya.Models
{
    public class TurGorevlisi
    {
        public int Id { get; set; }
        public string Adı { get; set; }
        public string Soyadı { get; set; }
        public Cinsiyet Cinsiyet { get; set; }
    }
    public enum Cinsiyet
    {
        Erkek = 1,
        Kadin = 2
    }
}

