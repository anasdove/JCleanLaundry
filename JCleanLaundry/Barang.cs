//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace JCleanLaundry
{
    using System;
    using System.Collections.Generic;
    
    public partial class Barang
    {
        public int Id { get; set; }
        public string Nama { get; set; }
        public int Harga { get; set; }
        public int TipeCuciId { get; set; }
    
        public virtual TipeCuci TipeCuciFK { get; set; }
    }
}
