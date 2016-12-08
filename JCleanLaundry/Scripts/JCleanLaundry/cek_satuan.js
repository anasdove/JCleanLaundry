(function () {

    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    window.jclean.web.cek_satuan = function () {

        var _tabelDetilSelector     = "#cek-satuan_tabel-transaksi";
        var _sumberData             = [];

        var _dataTableHelper    = jclean.web.dataTableHelper();

        var awal = function (url) {

            _tampilkanDetil(url);
        }

        var _tampilkanDetil = function (url) {

            var ajaxOpsi = {
                url         : url,
                type        : "GET",
                dataType    : "json",
                contentType : "application/json; charset=utf-8",
                success     : function (data) {

                    var columnDef = _setTabelDetilColumnDefinition();

                    _aturSumberData(data);

                    _dataTableHelper.loadTableClientSide(_tabelDetilSelector, _sumberData, columnDef, 10, [1, 5,10,15]);
                }
            };

            $.ajax(ajaxOpsi);
        }

        var _aturSumberData = function (data) {

            $.each(data, function (index, value) {

                var kodeTransaksi   = data[index].KodeTransaksi;
                var tglMasuk        = new Date(parseInt(data[index].TanggalMasuk.substr(6))).toLocaleString().split(",")[0];
                var counter         = data[index].NamaCounter;

                var detil           = [kodeTransaksi, tglMasuk , counter];

                _sumberData.push(detil);
            });
        }

        var _setTabelDetilColumnDefinition = function () {

            return [
                {
                    title       : "Kode"
                },

                {
                    title       : "Tanggal Masuk"
                },

                {
                    title       : "Counter"
                }
            ]
        }

        return {
            "awal"               : awal
        }
    }
}());

