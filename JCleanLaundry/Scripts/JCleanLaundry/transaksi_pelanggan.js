(function () {

    window.jclean = window.jclean || {};
    window.jclean.web = window.jclean.web || {};

    window.jclean.web.transaksi_pelanggan = function () {

        var cekNoHpPelanggan = function (url) {

            var ajaxOpsi = {

                url         : url,
                type        : "GET",
                dataType    : "json",
                data        : { "noHp": $("#Pelanggan_Hp").val() },
                contentType : "application/json; charset=utf-8",
                success     : function (returnValue) {

                    if (returnValue.noHpAda) {

                        _dataPelangganAktif(false);

                        _aktifkanTombolPeriksaNoHp(false);

                        _noHpAktif(false);

                        _masukkanDataPelanggan(returnValue.pelanggan);
                    } else {

                        _tampilkanerror(true);

                        _dataPelangganAktif(true);

                        _aktifkanTombolPeriksaNoHp(false);

                        _noHpAktif(true);
                    }
                }
            };

            $.ajax(ajaxOpsi);
        }

        var awal = function () {

            _dataPelangganAktif(false);

            _aktifkanTombolPeriksaNoHp(true);

            _noHpAktif(true);

            _tampilkanerror(false);
        }

        var _masukkanDataPelanggan = function (pelanggan) {

            $("#Pelanggan_Nama").val(pelanggan.Nama);

            $("#Pelanggan_NoKtp").val(pelanggan.NoKtp);

            $("#Pelanggan_Alamat").val(pelanggan.Alamat);
        }

        var _dataPelangganAktif = function (aktif) {

            var elements = $("#Pelanggan_Nama, #Pelanggan_NoKtp, #Pelanggan_Alamat");

            if (aktif) elements.removeAttr("disabled");

            else elements.attr("disabled", true);

            elements.val("");
        }

        var _aktifkanTombolPeriksaNoHp = function (aktif) {

            var buttonPeriksaPelanggan = $("#transaksi_btn-periksa-pelanggan");
            var buttonUlangCariPelanggan = $("#transaksi_btn-ulang-cari-pelanggan");

            if (aktif) {

                buttonPeriksaPelanggan.removeAttr("disabled");
                buttonUlangCariPelanggan.attr("disabled", true);
            } else {

                buttonPeriksaPelanggan.attr("disabled", true);
                buttonUlangCariPelanggan.removeAttr("disabled");
            }
        }

        var _noHpAktif = function (aktif) {

            if (aktif) {

                $("#Pelanggan_Hp").val("");
                $("#Pelanggan_Hp").removeAttr("disabled");
            } else {

                $("#Pelanggan_Hp").attr("disabled", true);
            }
        }

        var _tampilkanerror = function (aktif) {

            if (aktif) {

                $("#transaksi_div-pelanggan-error").show();
            } else {

                $("#transaksi_div-pelanggan-error").hide();
            }
        }

        // Mark specific method as public
        return {
            "cekNoHpPelanggan": cekNoHpPelanggan,
            "awal": awal
        }
    }
}());