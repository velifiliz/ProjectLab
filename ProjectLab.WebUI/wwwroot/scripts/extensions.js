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
            toastr.warning(msg, 'Uyar�');
        },
        info: function (msg) {
            toastr.info(msg, 'Bilgi');
        },
        success: function (msg) {
            toastr.success(msg, 'i�lem Ba�ar�l�');
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
        //    content: "Silme ��lemini Onayl�yormusunuz ? ",
        //    action: function () {
        //        console.log("i�lem Ba�ar�yla Ger�ekl�etirildi");
        //    }
        //});
    }

});