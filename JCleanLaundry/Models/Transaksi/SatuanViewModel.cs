﻿using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry.Models
{
    public class SatuanViewModel
    {
        public PelangganViewModel Pelanggan { get; set; }

        public BarangViewModel Barang { get; set; }

        [Required]
        [Display(Name="Pilih Barang")]
        public int KodeBarang { get; set; }

        [Required]
        [Display(Name = "Tipe")]
        public int KodeTipeCuci { get; set; }

        [Required]
        [Display(Name = "Jumlah")]
        public int Jumlah { get; set; }

        [DataType(DataType.Currency)]
        public int Harga { get; set; }

        [Display(Name = "Uang Muka")]
        public int UangMuka { get; set; }
    }
}