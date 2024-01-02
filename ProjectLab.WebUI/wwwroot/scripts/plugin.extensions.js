$.fn.extend({
    wait: function (state) {

        if (state) {
            $(this).waitMe({
                effect: 'ios', //win8 , win8_linear , ios , bounce
                //text: 'Lütfen Bekleyiniz',
                //bg: '#f3f4f961',
                //bg: 'rgba(255,255,255,0.1)',
                bg: 'transparent',
                color: '#000',
                textPos: 'vertical',
                fontSize: '13px',
                source: '',
                maxSize: 35,
                //waitTime: -1,
            });
        }
        else {
            $(this).waitMe('hide');
        }

        // $(".main").wait(true);  //false
    }

});