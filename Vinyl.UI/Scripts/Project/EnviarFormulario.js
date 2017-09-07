var btnAcao = $("input[type='button']");
var formulario = $("#formCrud");

btnAcao.on("click", submeter);

function submeter() {

    if (formulario.valid()) {

        var url = formulario.prop("action");
        var metodo = formulario.prop("method");
        var dadosFormulario = formulario.serialize();
        $.ajax({
            url: url,
            type: metodo,
            data: dadosFormulario,
            success: tratarRetorno
        });
    }
}

function tratarRetorno(resultadoServidor) {

    if (resultadoServidor.resultado) {
        toastr.options = {
            // toast-top-right / toast-top-left / toast-bottom-right / toast-bottom-left
            "positionClass": "toast-top-center",
            "showDuration": "300", // in milliseconds
        }
        toastr['success'](resultadoServidor.message);
        $('#myModal').modal('hide');
        $('#gridDados').bootgrid('reload');
    }
    else {
        toastr['error'](resultadoServidor.message, msgErro);
        btnAcao.prop("disabled", false);
    }
}
