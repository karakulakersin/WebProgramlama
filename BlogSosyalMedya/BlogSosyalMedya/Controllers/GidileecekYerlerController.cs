using BlogSosyalMedya.Data;
using BlogSosyalMedya.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogSosyalMedya.Controllers
{
//    public class GidileecekYerlerController : Controller


//    {
//        private ApplicationDbContext _context;
//        public GidileecekYerlerController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        var GidilecekYerlerList = (from g in _context.GidilecekYerler
//                                   join f in _context.TatilYerleri on g.Id equals f.Id
//                                   select new FilmDTO
//                                   {
//                                       Id = f.Id,
//                                       Adi = f.FilmAd,
//                                       Yil = f.Yil,
//                                       Uzunluk = f.Uzunluk,
//                                       Konu = f.Konu,
//                                       BaslangicZamani = g.Baslangic,
//                                       BitisZamani = g.Bitis,
//                                       Tur = f.Kategori.KategoriAd,
                                       
//                                   })

//                      .OrderBy(x => x.BaslangicZamani).ToList();

//;
//    }

//    var GidilecekYer = GidilecekYerlerList.Where(x => x="Gidilmedi").ToList();

//            return View(vizyon);
//}


//    }

    public class GidilecekYerlerDTD
{
    public string YerAdi { get; internal set; }
    public DateTime GidisTarihi { get; internal set; }
    public GidilmeDurumu GidilmeDurumu { get; internal set; }
    public int SehirId { get; set; }
    public Sehir Sehir { get; set; }
    public int UlkeId { get; set; }
    public Ulke Ulke { get; set; }
    public int KategoriId { get; set; }
    public Kategori Kategori { get; set; }
    public int Puani { get; set; }
    public String Fotograf { get; set; }
}

}
