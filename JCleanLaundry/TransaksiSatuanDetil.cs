
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace JCleanLaundry
{

using System;
    using System.Collections.Generic;
    
public partial class TransaksiSatuanDetil
{

    public int Kode { get; set; }

    public string KodeTransaksiSatuan { get; set; }

    public int KodeBarang { get; set; }

    public int Jumlah { get; set; }

    public string Pengecek { get; set; }

    public int Revisi { get; set; }



    public virtual Staff StaffFK { get; set; }

    public virtual Barang BarangFK { get; set; }

    public virtual TransaksiSatuan TransaksiSatuanFK { get; set; }

}

}
