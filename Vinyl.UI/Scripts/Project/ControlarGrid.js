function configurarControles() {

    /***** If necessary, customize to another language ****
        var traducao = {
            infos: "Exibindo {{ctx.start}} até {{ctx.end}} de {{ctx.total}} registros",
            loading: "Carregando, isso pode levar alguns segundos...",
            noResults: "Não há dados para exibir",
            refresh: "Atualizar",
            search: "Pesquisar"
    } 
    */

    var grid = $("#gridDados").bootgrid(
         {
             ajax: true,
             url: urlAction,

             // **** Call here if necessary ****
             //labels: traducao,

             searchSettings: {
                 characters: 3
             },

             formatters: {
                 "formActions": function (column, row) {
                     return "<a href='#' class='btn btn-info btn-sm' data-acao='Details' data-row-id='" + row.ID + "'>" +
                                 "<span class='glyphicon glyphicon-list'></span>" +
                            "</a> " +
                            "<a href='#' class='btn btn-warning btn-sm' data-acao='Edit' data-row-id='" + row.ID + "'>" +
                                 "<span class='glyphicon glyphicon-edit'></span>" +
                             "</a> " +
                            "<a href='#' class='btn btn-danger btn-sm' data-acao='Delete' data-row-id='" + row.ID + "'>" +
                                 "<span class='glyphicon glyphicon-trash'></span>" +
                            "</a> ";
                 },

                 "readonly": function (column, row) {
                     return "<a href='#' class='btn btn-info btn-sm' data-acao='Details' data-row-id='" + row.ID + "'>" +
                                 "<span class='glyphicon glyphicon-list'></span>" +
                            "</a> ";
                 },

                 "BirthDate": function (column, row) {
                     var MyDate_String_Value = ToJavaScriptDate(row.BirthDate);
                     return MyDate_String_Value;
                 }
             }
         });

    grid.on("loaded.rs.jquery.bootgrid", function () {

        grid.find("a.btn").each(function (index, elemento) {

            var actionButton = $(elemento);
            var acao = actionButton.data("acao");
            var idEntidade = actionButton.data("row-id");

            actionButton.on("click", function () {
                openModal(acao, idEntidade);
            })
        });
    });

    $("a.btn").click(function () {
        var acao = $(this).data("action");
        openModal(acao);
    })
}

function ToJavaScriptDate(value) {
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(value);
    var dt = new Date(parseFloat(results[1]));

    var dataFormatada = ("0" + dt.getDate()).substr(-2) + "/"
    + ("0" + (dt.getMonth() + 1)).substr(-2) + "/" + dt.getFullYear();

    //return (dt.getMonth() + 1) + "/" + dt.getDate() + "/" + dt.getFullYear();
    return dataFormatada;
}

function openModal(acao, parametro) {
    var url = "/{ctrl}/{acao}/{parametro}";

    url = url.replace("{ctrl}", controller);
    url = url.replace("{acao}", acao);
    if (parametro != null) {
        url = url.replace("{parametro}", parametro);
    }
    else {
        url = url.replace("{parametro}", "");
    }

    $("#contentModal").load(url, function () {
        $("#myModal").modal('show');
    });
}