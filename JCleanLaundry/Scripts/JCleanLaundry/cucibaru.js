var cucibaru_cekNoHpPelanggan = function(url) {
    var ajaxOpsi = {
        url: url,
        type: "GET",
        dataType: "json",
        data: { "noHp": $("#Pelanggan_Hp").val() },
        contentType: "application/json; charset=utf-8",
        success: function(returnValue) {
            if (returnValue.noHpAda) {
                _masukkanDataPelanggan(returnValue.pelanggan);
            } else {
                _aktifkanpelanggan();
                $("#cuci-baru_btn-periksa-pelanggan").attr("disabled", true);
            }
        }
    };

    $.ajax(ajaxOpsi);
}

var _masukkanDataPelanggan = function(pelanggan) {
    $("#Pelanggan_Nama").val(pelanggan.Nama);
    $("#Pelanggan_NoKtp").val(pelanggan.NoKtp);
    $("#Pelanggan_Alamat").val(pelanggan.Alamat);
}

var cucibaru_nonaktifkanpelanggan = function() {
    $("#Pelanggan_Nama").attr("disabled", true);
    $("#Pelanggan_NoKtp").attr("disabled", true);
    $("#Pelanggan_Alamat").attr("disabled", true);

    $("#cuci-baru_btn-periksa-pelanggan").removeAttr("disabled");
    $("#cuci-baru_btn-ulang-cari-pelanggan").attr("disabled", true);

    $("#cuci-baru_div-pelanggan-error").hide();
}

var _aktifkanpelanggan = function () {
    $("#cuci-baru_div-pelanggan-error").show();

    $("#Pelanggan_Nama").removeAttr("disabled");
    $("#Pelanggan_NoKtp").removeAttr("disabled");
    $("#cuci-baru_btn-ulang-cari-pelanggan").removeAttr("disabled");

    $("#Pelanggan_Alamat").removeAttr("disabled");

    $("#Pelanggan_Nama").val("");
    $("#Pelanggan_NoKtp").val("");
    $("#Pelanggan_Alamat").val("");
}