$(function () {

    $.http = {
        post: (url, param, callback, wait) => { 
            wait && $(wait.join(", ")).wait(true)
            $.post(url, param)
                .then((response) => {
                    callback(response)
                })
                .done(() => {
                    $.logg("ajax-done");
                    $(wait).wait(false)
                })
                .fail((err) => {
                    var error = { status: err.status, text: err.statusText }
                    $.logg(error); 
                }).always(() => {
                    wait && $(wait.join(", ")).wait(false)
                });
            return false;
        },
        get: (url, param, callback, wait) => {
            wait && $(wait.join(", ")).wait(true)
            $.get(url, param)
                .then((response) => {
                    callback(response)
                })
                .done(() => {
                    $.logg("ajax-done");
                    $(wait).wait(false)
                })
                .fail((err) => {
                    var error = { status: err.status, text: err.statusText }
                    $.logg(error);
                    $.alert.error("�stek S�ras�nda Bir Hata Meydana Geldi");
                }).always(() => {
                    wait && $(wait.join(", ")).wait(false)
                });
            return false;
        }
    }

});