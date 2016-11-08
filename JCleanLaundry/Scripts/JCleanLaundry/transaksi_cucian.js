(function () {
    // Declare namespace
    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    window.jclean.web.transaksi_cucian = function () {

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

        // Mark specific method as public
        return {
            "tampilkanBarang": tampilkanBarang
        }
    }
}());

