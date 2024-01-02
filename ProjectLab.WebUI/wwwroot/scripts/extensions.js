$.extend({

    logg: (msg) => {
        var debug = false;
        if (debug) {
            console.log(msg);
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