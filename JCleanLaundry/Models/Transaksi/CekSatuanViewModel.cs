using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry.Models
{
    public class CekSatuanViewModel
    {
        [Display(Name = "Kode")]
        public string Kode { get; set; }

        [Display(Name = "Total Bayar")]
        [DisplayFormat(DataFormatString = "{0:#.####}")]
        public decimal TotalBayar { get; set; }

        public string Staff { get; set; }

        public IEnumerable<CekSatuanDetilViewModel> Detail { get; set; }
    }
}