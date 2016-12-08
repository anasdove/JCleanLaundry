using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry.Models
{
    public class ProsesSatuanViewModel
    {
        [Display(Name = "Kode")]
        public string KodeTransaksi { get; set; }

        [Display(Name = "Pelanggan")]
        public PelangganViewModel Pelanggan { get; set; }

        [Display(Name = "Uang Muka")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal UangMuka { get; set; }

        [Display(Name = "Total Bayar")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal TotalBayar { get; set; }

        [Display(Name = "Tgl Masuk")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TanggalMasuk { get; set; }

        [Display(Name = "Tgl Selesai")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TanggalSelesai { get; set; }

        [Display(Name = "Counter")]
        public string NamaCounter { get; set; }

        public string Staff { get; set; }

        public IEnumerable<ProsesSatuanDetailViewModel> Detail { get; set; }
    }
}