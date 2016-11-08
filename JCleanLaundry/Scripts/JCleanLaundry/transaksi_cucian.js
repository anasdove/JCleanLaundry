(function () {
    // Declare namespace
    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    window.jclean.web.transaksi_cucian = function () {

        // Global variable
        var _tabelBarangSelector = "#satuan_tabel-barang";
        var _dataSource = null;
        var _defaultDataSource = [["-", "-", "-"]];

        var _dataTableHelper = jclean.web.dataTableHelper();

        var tampilkanTabelBarangAwal = function () {

            var columnDef = _setTabelBarangColumnDefinition();

            _dataSource = _defaultDataSource;

            _dataTableHelper.loadTableClientSideWithoutURL(_tabelBarangSelector, _dataSource, columnDef);

        }

        var masukkanDataKeTabelBarang = function () {
            var tipe = $("#satuan_ddl-tipecucian option:selected").text();
            var barang = $("#satuan_ddl-barang option:selected").text();
            var jumlah = $("#Jumlah").val();

            var columnDef = _setTabelBarangColumnDefinition();

            if (_dataSource == _defaultDataSource) {
                _dataSource = [[tipe, barang, jumlah]];

                _dataTableHelper.loadTableClientSideWithoutURL(_tabelBarangSelector, _dataSource, columnDef);
            } else {
                var newData = [tipe, barang, jumlah];

                _dataSource.push(newData);

                _dataTableHelper.loadTableClientSideWithoutURL(_tabelBarangSelector, _dataSource, columnDef);
            }
        }

        var tampilkanBarang = function (value, url) {
            var ProcessingInstruction = "<option value='0'> Please wait...</option>";
            $("#satuan_ddl-barang").html(ProcessingInstruction).show();

            var ajaxOpsi = {
                url: url,
                type: "GET",
                dataType: "json",
                data: { "tipeCuciId": value },
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    
                    var markup = null;

                    for (var x = 0; x < data.length; x++) {
                        markup += "<option value=" + data[x].Value + ">" + data[x].Text + "</option>";
                    }

                    $("#satuan_ddl-barang").html(markup).show();

                }
            };

            $.ajax(ajaxOpsi);

        }

        // Set Column Definition for Tabel Barang
        var _setTabelBarangColumnDefinition = function () {
            return [
                { title: "Tipe" },

                { title: "Barang" },

                { title: "Jumlah" }
            ]
        }

        // Mark specific method as public
        return {
            "tampilkanBarang": tampilkanBarang,
            "tampilkanTabelBarangAwal": tampilkanTabelBarangAwal,
            "masukkanDataKeTabelBarang": masukkanDataKeTabelBarang
        }
    }
}());

