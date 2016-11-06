var cucibaru_cekNoHpPelanggan = function(url) {
    var ajaxOpsi = {
        url: url,
        type: "GET",
        dataType: "json",
        data: { "noHp": $("#Pelanggan_Hp").val() },
        contentType: "application/json; charset=utf-8",
        success: function(returnValue) {
            if (returnValue.noHpAda) {
                _pelanggan_dataPelangganAktif(false);
                _pelanggan_aktifkanTombolPeriksaNoHp(false);
                _pelanggan_noHpAktif(false);
                _pelanggan_masukkanDataPelanggan(returnValue.pelanggan);
            } else {
                _pelanggan_tampilkanerror(true);
                _pelanggan_dataPelangganAktif(true);
                _pelanggan_aktifkanTombolPeriksaNoHp(false);
                _pelanggan_noHpAktif(true);
            }
        }
    };

    $.ajax(ajaxOpsi);
}

var cucibaru_pelanggan_awal = function() {
    _pelanggan_dataPelangganAktif(false);
    _pelanggan_aktifkanTombolPeriksaNoHp(true);
    _pelanggan_noHpAktif(true);
    _pelanggan_tampilkanerror(false);
}

var _pelanggan_masukkanDataPelanggan = function (pelanggan) {
    $("#Pelanggan_Nama").val(pelanggan.Nama);
    $("#Pelanggan_NoKtp").val(pelanggan.NoKtp);
    $("#Pelanggan_Alamat").val(pelanggan.Alamat);
}

var _pelanggan_dataPelangganAktif = function(aktif) {
    if (aktif) {
        $("#Pelanggan_Nama, #Pelanggan_NoKtp, #Pelanggan_Alamat").removeAttr("disabled");
    } else {
        $("#Pelanggan_Nama, #Pelanggan_NoKtp, #Pelanggan_Alamat").attr("disabled", true);
    }

    $("#Pelanggan_Nama, #Pelanggan_NoKtp, #Pelanggan_Alamat").val("");
}

var _pelanggan_aktifkanTombolPeriksaNoHp = function(aktif) {
    if (aktif) {
        $("#cuci-baru_btn-periksa-pelanggan").removeAttr("disabled");
        $("#cuci-baru_btn-ulang-cari-pelanggan").attr("disabled", true);
    } else {
        $("#cuci-baru_btn-periksa-pelanggan").attr("disabled", true);
        $("#cuci-baru_btn-ulang-cari-pelanggan").removeAttr("disabled");
    }
}

var _pelanggan_noHpAktif = function(aktif) {
    if (aktif) {
        $("#Pelanggan_Hp").val("");
        $("#Pelanggan_Hp").removeAttr("disabled");
    } else {
        $("#Pelanggan_Hp").attr("disabled", true);
    }
}

var _pelanggan_tampilkanerror = function(aktif) {
    if (aktif) {
        $("#cuci-baru_div-pelanggan-error").show();
    } else {
        $("#cuci-baru_div-pelanggan-error").hide();
    }
}