using System.Collections.Generic;

namespace JCleanLaundry.Models
{
    public class ProsesSatuanViewModel
    {
        public PelangganViewModel Pelanggan { get; set; }

        public int UangMuka { get; set; }

        public IEnumerable<ProsesSatuanDetailViewModel> Detail { get; set; }
    }
}