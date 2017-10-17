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
    console.log(resultadoServidor.message);
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
        //toastr['error'](resultadoServidor.message);
        DisplayErrors(resultadoServidor.message);
        btnAcao.prop("disabled", false);
    }
}

function DisplayErrors(errors) {
    console.log(errors);
    toastr.options = {
        "positionClass": "toast-top-center",
        "showDuration": "300",
    }
    console.log("Length: " +errors.length);
    for (var i = 0; i < errors.length; i++) {
        toastr['error'](errors[i].Value[0]);
    }
    btnAcao.prop("disabled", false);
}