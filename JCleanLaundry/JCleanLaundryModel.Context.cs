﻿

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
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class JCleanLaundryEntities : DbContext
{
    public JCleanLaundryEntities()
        : base("name=JCleanLaundryEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<Barang> Barangs { get; set; }

    public virtual DbSet<Pelanggan> Pelanggans { get; set; }

    public virtual DbSet<TipeCuci> TipeCucis { get; set; }

    public virtual DbSet<Staff> Staffs { get; set; }

    public virtual DbSet<Counter> Counters1 { get; set; }

    public virtual DbSet<StaffCounter> StaffCounters { get; set; }

    public virtual DbSet<TransaksiSatuan> TransaksiSatuans { get; set; }

    public virtual DbSet<TransaksiSatuanDetil> TransaksiSatuanDetils { get; set; }

}

}

