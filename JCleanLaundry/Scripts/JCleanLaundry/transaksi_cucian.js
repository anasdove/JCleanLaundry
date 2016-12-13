(function () {
    // Declare namespace
    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    window.jclean.web.transaksi_cucian = function () {

        // Global variable
        var _tabelBarangSelector    = "#satuan_tabel-barang";
        var _dataSource             = [];

        var _dataTableHelper = jclean.web.dataTableHelper();

        var tampilkanTabelBarangAwal = function () {

            var columnDef = _setTabelBarangColumnDefinition();

            _dataTableHelper.loadTableClientSideWithoutURL(_tabelBarangSelector, _dataSource, columnDef);

        }

        var masukkanDataKeTabelBarang = function () {

            var tipe            = $("#satuan_ddl-tipecucian option:selected").text();
            var kodeBarang      = $("#satuan_ddl-barang option:selected").val();
            var barang          = $("#satuan_ddl-barang option:selected").text();
            var jumlah          = $("#Jumlah").val();
            var harga           = Number($("#satuan_text-harga").val().replace(/[^0-9\.]+/g,""));

            // Set Validation
            // Ga bisa nginput data yg sama (otomatis di tambah)
            if (!_periksaDetailCucian(jumlah, harga)) {

                return;
            }

            var columnDef = _setTabelBarangColumnDefinition();

            var newData = [kodeBarang, tipe, barang, jumlah, harga];

            _dataSource.push(newData);

            _dataTableHelper.loadTableClientSideWithoutURL(_tabelBarangSelector, _dataSource, columnDef);

            _updateTotalBayar();

            _hapusJumlah();
        }

        var tampilkanBarang = function (value, url) {

            var ProcessingInstruction = "<option value='0'> Please wait...</option>";

            $("#satuan_ddl-barang").html(ProcessingInstruction).show();

            var ajaxOpsi = {
                url         : url,
                type        : "GET",
                dataType    : "json",
                data        : { "kodeTipeCuci": value },
                contentType : "application/json; charset=utf-8",
                success     : function (data) {
                    
                    var markup = null;

                    for (var x = 0; x < data.length; x++) {

                        markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                    }

                    $("#satuan_ddl-barang").html(markup).show();

                    _hapusHarga();
                }
            };

            $.ajax(ajaxOpsi);

        }

        var tampilkanHarga = function (value, url) {

            if (value == 0) {

                _hapusHarga();
                return;
            }

            var ajaxOpsi = {
                url: url,
                type: "GET",
                dataType: "json",
                data: { "kodeBarang": value },
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    $("#satuan_text-harga").val(data.toLocaleString());

                    $("#Jumlah").val(1);
                }
            };

            $.ajax(ajaxOpsi);
        }

        var hapusBarangDariTabel = function (row) {

            var tipe    = $(row).children()[0].textContent;
            var barang  = $(row).children()[1].textContent;

            if (tipe == "-") {

                return;
            }

            brg = _dataSource.filter(function (data) {

                return data[1] == tipe && data[2] == barang
            });

            var indexBrg = _dataSource.indexOf(brg[0]);

            _dataSource.splice(indexBrg, 1);
                        
            var columnDef = _setTabelBarangColumnDefinition();

            _dataTableHelper.loadTableClientSideWithoutURL(_tabelBarangSelector, _dataSource, columnDef);

            _updateTotalBayar();
        }

        var prosesTransaksiSatuan = function (url, cetakUrl) {

            var uangMuka = $("#UangMuka").val();

            if (!_periksaDataPelanggan()) {

                _tampilkanPeringatan("Data Pelanggan belum diisi");

                return;
            }

            if (!_periksaDaftarDetailCucian()) {

                _tampilkanPeringatan("Detil Cucian belum diisi");

                return;
            }

            if (!_periksaUangMuka(uangMuka)) {

                _tampilkanPeringatan("Salah memasukan uang muka");

                $("#UangMuka").val("");

                return;
            }

            // Panggil Controller
            _simpanTransaksi(url, cetakUrl);
        }

        var _setTabelBarangColumnDefinition = function () {

            return [
                {
                    title       : "Kode Barang",
                    visible     : false
                },

                {
                    title       : "Tipe"
                },

                {
                    title       : "Barang"
                },

                {
                    title       : "Jumlah"
                },

                {
                    title       : "Harga",
                    visible     : false
                }
            ]
        }

        var _hapusHarga = function () {

            $("#satuan_text-harga").val("");
        }

        var _hapusJumlah = function () {

            $("#Jumlah").val("");
        }

        var _updateTotalBayar = function () {

            var $totalBayar = 0;

            $.each(_dataSource, function (index, value) {

                var harga   = _dataSource[index][4];
                var jumlah  = _dataSource[index][3];

                $totalBayar = $totalBayar + (harga * jumlah);
            })

            $("#div_satuan-total-bayar").html($totalBayar.toLocaleString());
        }

        var _periksaDetailCucian = function (jumlah, harga) {

            if (isNaN(jumlah) || jumlah < 1 || harga == 0) {
                
                _tampilkanPeringatan("Salah masukkan jumlah");

                _hapusJumlah();

                $("#Jumlah").focus();

                return false;
            }

            return true;
        }

        var _periksaDataPelanggan = function () {

            var benar = true;

            if ($("#Pelanggan_Nama").val() == "") {

                benar = false;
            }

            if ($("#Pelanggan_NoKtp").val() == "") {

                benar = false;
            }

            if ($("#Pelanggan_Alamat").val() == "") {

                benar = false;
            }

            if ($("#Pelanggan_Hp").val() == "") {

                benar = false;
            }

            return benar;
        }

        var _periksaDaftarDetailCucian = function () {

            var benar = true;

            if (_dataSource.length == 0) {

                benar = false;
            }

            return benar;
        }

        var _periksaUangMuka = function (uangMuka) {

            var benar = true;

            var uangMuka = $("#UangMuka").val();

            if (isNaN(uangMuka)) {

                benar = false;
            }

            if (uangMuka < 0) {

                benar = false;
            }

            var harga = Number($("#div_satuan-total-bayar").html().replace(/[^0-9\.]+/g,""));

            if (uangMuka > harga) {

                benar = false;
            }

            return benar;
        }

        var _simpanTransaksi = function (url, cetakUrl) {

            var transaksiData = [];

            $.each(_dataSource, function (index, val) {

                var kodeBarang      = _dataSource[index][0];
                var jumlah          = _dataSource[index][3];

                var nama            = $("#Pelanggan_Nama").val();
                var hp              = $("#Pelanggan_Hp").val();
                var ktp             = $("#Pelanggan_NoKtp").val();
                var alamat          = $("#Pelanggan_Alamat").val();

                var uangMuka        = $("#UangMuka").val();

                var data = [kodeBarang, jumlah, nama, hp, ktp, alamat, uangMuka];

                transaksiData.push(data);
            })

            var ajaxOpsi = {
                url: url,
                type: "POST",
                dataType: "json",
                data: JSON.stringify(transaksiData),
                traditional: true,
                contentType: "application/json; charset=utf-8",
                success: function (data) {

                    if (data == "") {

                        _tampilkanPeringatan("Gagal melakukan transaksi satuan. Coba lagi");

                        return;
                    }

                    _tampilkanPeringatan("Transaksi Satuan Berhasil");

                    window.location.href = cetakUrl.replace('__id__', data);
                }
            };

            $.ajax(ajaxOpsi);
        }

        var _tampilkanPeringatan = function (peringatan) {

            $("#div-errorModal").modal();
            $("#div-errorModalContainer").html(peringatan);
        }

        // Mark specific method as public
        return {
            "tampilkanBarang"               : tampilkanBarang,
            "tampilkanTabelBarangAwal"      : tampilkanTabelBarangAwal,
            "masukkanDataKeTabelBarang"     : masukkanDataKeTabelBarang,
            "tampilkanHarga"                : tampilkanHarga,
            "hapusBarangDariTabel"          : hapusBarangDariTabel,
            "prosesTransaksiSatuan"         : prosesTransaksiSatuan
        }
    }
}());

