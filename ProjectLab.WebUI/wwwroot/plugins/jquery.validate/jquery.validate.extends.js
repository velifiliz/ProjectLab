// <reference path="jquery.js" />
// <reference path="jquery.validate.js" />
(function ($) {
    $.fn.setValidateOption = function (opt) {
        var data = $(this).data("validator");
        if (!data) {
            $(this).validate(opt);
            return;
        }
        data.settings = $.extend(data.settings, opt);
        $(this).data("validator", data);
    };

    $.fn.getValidateOption = function (name) {
        var data = $(this).data("validator");
        if (!data) return null;
        if (!data.settings) return null;
        var obj = data.settings[name];
        if (!obj) return null;
        return obj;
    };

    $.fn.setNewValidateOption = function (name, value) {
        var old = $(this).getValidateOption(name);
        
        if (typeof (value) === "function") {
            setValue($(this),name, value(old));
        } else {
            setValue($(this), name, value);
        }

        function setValue(obj, n, v) {
            var datakey = "validator";
            var data = obj.data(datakey);
            if (!data || !data.settings) return;
            data.settings[name] = v;
            obj.data(datakey, data);
        }

    };

})(jQuery)