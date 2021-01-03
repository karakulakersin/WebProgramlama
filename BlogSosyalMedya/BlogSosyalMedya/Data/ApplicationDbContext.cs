using BlogSosyalMedya.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogSosyalMedya.Data
{
    public class ApplicationDbContext : IdentityDbContext<Kullanici>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<TatilYerleri> TatilYerleri { get; set;  }
        public DbSet<Sehir> Sehir { get; set; }
        public DbSet<Ulke> Ulke { get; set; }
        public DbSet<TatilTuru> TatilTuru { get; set; }
        public DbSet<TurGorevlisi> TurGorevlisi { get; set; }
        public DbSet<Otel> Otel { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<BlogSosyalMedya.Models.GidilecekYerler> GidilecekYerler { get; set; }

    }
}
