
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
    
public partial class Barang
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Barang()
    {

        this.TransaksiSatuanDetilFK = new HashSet<TransaksiSatuanDetil>();

    }


    public int Kode { get; set; }

    public string Nama { get; set; }

    public int Harga { get; set; }

    public int KodeTipeCuci { get; set; }



    public virtual TipeCuci TipeCuciFK { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

    public virtual ICollection<TransaksiSatuanDetil> TransaksiSatuanDetilFK { get; set; }

}

}
