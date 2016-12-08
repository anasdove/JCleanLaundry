(function () {

    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    window.jclean.web.cetak_transaksi = function () {

        var _tabelDetilSelector     = "#cetak-transaksi_table-detil";
        var _dataSource             = [];

        var _dataTableHelper    = jclean.web.dataTableHelper();

        var awal = function () {

            var columnDef = _setTabelDetilColumnDefinition();



            _dataTableHelper.loadTableClientSideWithoutURL(_tabelDetilSelector, _dataSource, columnDef);

        }

        var _tampilkanDetil = function () {

            var ajaxOpsi = {
                url         : url,
                type        : "GET",
                dataType    : "json",
                data        : { "kodeBarang": value },
                contentType : "application/json; charset=utf-8",
                success     : function (data) {

                    $("#satuan_text-harga").val(data.toLocaleString());

                    $("#Jumlah").val(1);
                }
            };

            $.ajax(ajaxOpsi);
        }

        var _setTabelDetilColumnDefinition = function () {

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

        return {
            "awal"               : awal
        }
    }
}());

