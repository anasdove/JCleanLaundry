using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry.Models
{
    public class BarangViewModel
    {
        public int Kode { get; set; }

        [Required]
        public string Nama { get; set; }

        [Required]
        public int Harga { get; set; }

        [Required]
        [Display(Name="Tipe Cucian")]
        public int KodeTipeCuci { get; set; }

        public TipeCuciViewModel TipeCuci { get; set; }

        public string TipeCuciNama { get; set; }
    }
}