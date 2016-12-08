using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry.Models
{
    public class PelangganViewModel
    {
        public int Kode { get; set; }

        [Required]
        public string Nama { get; set; }

        [Required]
        [Display(Name="No HP")]
        public string Hp { get; set; }

        [Required]
        [Display(Name="No KTP")]
        public string NoKtp { get; set; }

        public string Alamat { get; set; }
    }
}