$.extend({

    logg: (msg) => {
        var debug = false;
        if (debug) {
            console.log(msg);
        }
    },

    alert: {
        error: function (msg) {
            toastr.error(msg, 'Hata');
        },
        warning: function (msg) {
            toastr.warning(msg, 'Uyarý');
        },
        info: function (msg) {
            toastr.info(msg, 'Bilgi');
        },
        success: function (msg) {
            toastr.success(msg, 'iþlem Baþarýlý');
        }
    },

    accept: (params) => {
        var type   = params.alert == true ? "red" : "blue";
        var title  = params.alert == true ? "UYARI" : "BiLGi";
        $.confirm({
            title: title,
            content: params.content,
            draggable: false,
            type: type,
            theme: 'light',
            typeAnimated: true,
            animateFromElement: false,
            animation: "opacity",
            closeAnimation: "opacity",
            buttons: {
                accept: {
                    text: 'TAMAM',
                    btnClass: 'btn-' + type,
                    action: params.action
                },
                close: {
                    text: 'KAPAT',
                    action: params.close
                }
            }
        });
        //$.accept({
        //    alert:true, 
        //    content: "Silme Ýþlemini Onaylýyormusunuz ? ",
        //    action: function () {
        //        console.log("iþlem Baþarýyla Gerçeklþetirildi");
        //    }
        //});
    }

});