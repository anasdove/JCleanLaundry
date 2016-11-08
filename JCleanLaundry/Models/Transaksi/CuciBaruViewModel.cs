using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry.Models
{
    public class CuciBaruViewModel
    {
        public PelangganViewModel Pelanggan { get; set; }

        public BarangViewModel Barang { get; set; }

        [Required]
        [Display(Name="Pilih Barang")]
        public int BarangId { get; set; }

        [Required]
        [Display(Name = "Tipe")]
        public int TipeCucian { get; set; }
    }
}