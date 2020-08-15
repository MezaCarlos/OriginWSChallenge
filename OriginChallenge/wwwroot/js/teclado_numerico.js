(function ($) {

    

    $.fn.tecladoNumerico = function (inputPadre) {

        $(this).on('click', function () {
            let $inputPadre = $('#' + inputPadre);
            var maxlength = $inputPadre.attr('maxlength');

            if (maxlength === 'undefided' || maxlength <= $inputPadre.val().length) 
                return false   
            
            let texto = $('#' + inputPadre).val();
            texto += $(this).val();
            $('#' + inputPadre).val(texto);
        });

        return this;
    };


}(jQuery));