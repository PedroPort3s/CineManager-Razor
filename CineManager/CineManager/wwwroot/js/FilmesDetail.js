$(document).ready(function () {
    GeneroModalDetail($('#IdFilme').val());
    TipoFilmeModalDetail($('#IdFilme').val());
});

// Filme Generos

function GeneroModalDetail(id) {
    var genFilme = $.ajax({
        url: '/Filme/GenerosFilmeDetail',
        data: {
            id : id
        }
    });
    genFilme.done(function (data) {
        $('#divPartialDetail').html(data);
    });
}
function GeneroModalOpen() {
    $('#ShowModalDetail').modal('show');
}

//Filme Tipo

function TipoFilmeModalDetail(id) {
    var tipoFilme = $.ajax({
        url: '/Filme/TiposFilmeDetail',
        data: {
            id : id
        }
    });
    tipoFilme.done(function (data) {
        $('#divPartialDetailTF').html(data);
    });
}
function TipoFilmeModalOpen() {
    $('#ShowModalDetailTF').modal('show');
}

